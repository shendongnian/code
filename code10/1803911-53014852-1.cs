    using System.ComponentModel;
    using System.Windows.Media;
    
    namespace Question_Answer_WPF_App
    {
        public class BackgroundViewModel : INotifyPropertyChanged
        {
            private readonly SolidColorBrush DefaultBrush = new SolidColorBrush(Colors.BlueViolet);
            private Brush background;
            public event PropertyChangedEventHandler PropertyChanged;
            public BackgroundViewModel() => background = DefaultBrush;
    
            public Brush Background
            {
                get => background;
                set
                {
                    background = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Background)));
                }
            }
        }
    }
