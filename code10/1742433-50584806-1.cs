    public class MySimpleViewModel : INotifyPropertyChanged
    {
        private string theString = String.Empty;
    
        public string TheString
        {
            get => this.theString;
            set
            {
                if(this.theString != value)
                {
                    this.RaisePropertyChanged();
                    this.theString = value;
                }
            }
        }
            
        public event PropertyChangedEventHandler PropertyChanged;
    
        public virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
