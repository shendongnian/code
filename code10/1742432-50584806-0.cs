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
    
        [NotifyPropertyChangedInvocator]
        public virtual void RaisePropertyChanged([CallerMemberName][CanBeNull] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
