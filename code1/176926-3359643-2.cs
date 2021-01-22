    using System;
    using System.Collections.Concurrent;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;
    using Microsoft.Win32;
    namespace BackgroundProcessing
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly BlockingCollection<BitmapImage> _blockingCollection = new BlockingCollection<BitmapImage>();
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private ImageSource _processedImage;
        public MainWindow()
        {
            InitializeComponent();
            CancellationToken cancelToken = _tokenSource.Token;
            Task.Factory.StartNew(() => ProcessBitmaps(cancelToken), cancelToken);
            PendingImages = new ObservableCollection<BitmapImage>();
            DataContext = this;
        }
        public ObservableCollection<BitmapImage> PendingImages { get; private set; }
        public ImageSource ProcessedImage
        {
            get { return _processedImage; }
            set
            {
                _processedImage = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("ProcessedImage"));
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        private void ProcessBitmaps(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                BitmapImage image;
                try
                {
                    image = _blockingCollection.Take(token);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
                FormatConvertedBitmap grayBitmapSource = ConvertToGrayscale(image);
                Dispatcher.BeginInvoke((Action) (() =>
                                                     {
                                                         ProcessedImage = grayBitmapSource;
                                                         PendingImages.Remove(image);
                                                     }));
                Thread.Sleep(1000);
            }
        }
        private static FormatConvertedBitmap ConvertToGrayscale(BitmapImage image)
        {
            var grayBitmapSource = new FormatConvertedBitmap();
            grayBitmapSource.BeginInit();
            grayBitmapSource.Source = image;
            grayBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            grayBitmapSource.EndInit();
            grayBitmapSource.Freeze();
            return grayBitmapSource;
        }
        protected override void OnClosed(EventArgs e)
        {
            _tokenSource.Cancel();
            base.OnClosed(e);
        }
        private void BrowseForFile(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
                             {
                                 InitialDirectory = "c:\\",
                                 Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp",
                                 Multiselect = true
                             };
            if (!dialog.ShowDialog().GetValueOrDefault(false)) return;
            foreach (string name in dialog.FileNames)
            {
                CreateBitmapAndAddToProcessingCollection(name);
            }
        }
        private void CreateBitmapAndAddToProcessingCollection(string name)
        {
            Dispatcher.BeginInvoke((Action)(() =>
                                                {
                                                    var uri = new Uri(name);
                                                    var image = new BitmapImage(uri);
                                                    image.Freeze();
                                                    PendingImages.Add(image);
                                                    _blockingCollection.Add(image);
                                                }), DispatcherPriority.Background);
        }
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
    }
