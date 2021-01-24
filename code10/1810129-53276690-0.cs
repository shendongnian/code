    public class VM : System.ComponentModel.INotifyPropertyChanged
    {
        private string title;
        private SolidColorBrush background;
        public string Title { get => title; set { title = value; RaisePropertyChanged(); } }
        public SolidColorBrush Background { get => background; set { background = value; RaisePropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class VM1: VM
    {
        public VM1()
        {
            Title = "This is VM1";
            Background = Brushes.Yellow;
        }
    }
    public class VM2: VM
    {
        public VM2()
        {
            Title = "This is VM2";
            Background = Brushes.Orange;
        }
    }
