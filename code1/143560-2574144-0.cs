    // MainWindow.xaml
    <Window x:Class="MainWindow" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    		Title="MainWindow" Height="350" Width="525">
    	<DockPanel>
    		<Image Source="{Binding ImageSource}" />
    	</DockPanel>
    </Window>
    
    // MainWindow.xaml.cs
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            var model = new MainModel();
            DataContext = model;
    
            model.SetImageData(File.ReadAllBytes(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg"));
        }
    }
    
    class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void SetImageData(byte[] data) {
            var source = new BitmapImage();
            source.BeginInit();
            source.StreamSource = new MemoryStream(data);
            source.EndInit();
    
            // use public setter
            ImageSource = source;
        }
    
        ImageSource imageSource;
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }
    
        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
