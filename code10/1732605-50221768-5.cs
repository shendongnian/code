    public class RectOverlay : INotifyPropertyChanged
    {
        private double wwidth;
        public double wWidth
        {
            get { return wwidth; }
            set
            {
                wwidth = value;
                OnPropertyChanged(nameof(wWidth));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
