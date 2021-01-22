    public class MyModel : INotifyPropertyChanged
    {
        private DataInstance currentDataInstance;
        public event PropertyChangedEventHandler PropertyChanged;
        public DataInstance CurrentDataInstance
        {
            get
            {
                return this.currentDataInstance;
            }
            set
            {
                if ( this.currentDataInstance == value )
                    return;
                this.currentDataInstance = value;
                this.OnPropertyChanged( new PropertyChangedEventArgs("CurrentDataInstance"));
            }
        }
        protected virtual void OnPropertyChanged( PropertyChangedEventArgs e )
        {
            if ( this.PropertyChanged != null )
                this.PropertyChanged( this, e );
        }
    }
