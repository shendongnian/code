    public class ViewModel : INotifyPropertyChanged
    {
        private int width, height;
        public int Width { get { return width; } set { width = value; RisePropertyChanged(); } }
        public int Height { get { return height; } set { height = value; RisePropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
