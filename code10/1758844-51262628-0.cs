    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Documents.DocumentStructures;
    using System.Windows.Input;
    using ButtonPopup.View.ViewModel;
    namespace ButtonPopup
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new DataContextObject();
            }
        }
        public class DataContextObject : INotifyPropertyChanged
        {
            private bool _isPrintPopupOpen;
            public bool IsPrintPopupOpen
            {
                get { return _isPrintPopupOpen; }
                set
                {
                    if (_isPrintPopupOpen == value)
                    {
                        return;
                    }
                    _isPrintPopupOpen = value;
                    OnPropertyChanged(nameof(IsPrintPopupOpen));
                }
            }
            public ICommand PrintCommand => new RelayCommand(InitiatePrint);
            private async void InitiatePrint(object obj)
            {
                IsPrintPopupOpen = true;
                await Task.Delay(3000);
                IsPrintPopupOpen = false;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
