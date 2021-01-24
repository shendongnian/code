    public class PageViewModel : INotifyPropertyChanged
    {
        private bool loadGrid;
    
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
    
        public bool LoadGrid
        {
            get { return this.loadGrid; }
            set
            {
                this.loadGrid = value;
                this.OnPropertyChanged();
            }
        }
    
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
