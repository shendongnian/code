    public class BindableRow : INotifyPropertyChanged, IDictionary<string, object>
    {
        private Dictionary<string, object> _data = new Dictionary<string, object>( );
        public object Dummy   // Provides a dummy property for the column to bind to
        {
            get
            {
                return this;
            }
            set
            {
                var o = value;
            }
        }
        public object this[ string index ]
        {
            get
            {
                return _data[ index ];
            }
            set
            {
                _data[ index ] = value;
                InvokePropertyChanged( new PropertyChangedEventArgs( "Dummy" ) ); // Trigger update
            }
        }
    }
