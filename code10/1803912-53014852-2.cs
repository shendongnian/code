    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace Question_Answer_WPF_App.ViewModels
    {
        public class BackgroundViewModel : INotifyPropertyChanged
        {
            private Brush selectedBackground;
    
            public BackgroundViewModel()
            {
                var brushes = new List<Brush>
                {
                    new SolidColorBrush(Colors.BlueViolet),
                    new ImageBrush(new BitmapImage(new Uri("http://i.stack.imgur.com/jGlzr.png", UriKind.Absolute))),
                    new LinearGradientBrush(Colors.Black, Colors.White, 45)
                };
                BackgroundOptions = brushes;
                SelectedBackground = BackgroundOptions.FirstOrDefault();
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public IEnumerable<Brush> BackgroundOptions { get; }
    
            public Brush SelectedBackground
            {
                get => selectedBackground;
                set
                {
                    selectedBackground = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBackground)));
                }
            }
        }
    }
