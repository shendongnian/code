    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Image originalImage;
        public Image OriginalImage
        {
            get => originalImage;
            set 
            {
                originalImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OriginalImage)); //Notify the property is changing.
            }
        }
    }
