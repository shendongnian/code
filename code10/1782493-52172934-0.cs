    public class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(IsVisible)));
                }
            }
        }
    }
    public class ViewModel
    {
        public List<Cell> Cells { get; } =
            Enumerable.Range(0, 4096).Select(i => new Cell()).ToList();
    }
