    public class SubSystem : INotifyPropertyChanged
    {
        private string mName;
        private Boolean mIsSelected = false;
    
        public SubSystem()
        {
        }
    
        public SubSystem(string name, Boolean isSelected)
        {
            this.Name = name;
            this.IsSelected = isSelected;
        }
    
        public string Name
        {
            get { return mName; }
            set
            {
                if (mName != value)
                {
                    mName = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
    
        public Boolean IsSelected
        {
            get { return mIsSelected; }
            set
            {
                if (mIsSelected != value)
                {
                    mIsSelected = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
                }
            }
        }
    
        #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        #endregion
    }
