    public class DummyViewModel
    {
        public Weather Weather { get; set; }        
    
        public DummyViewModel() 
        { 
            this.Weather = new Weather();
        }
    
        public DummyViewModel(int humidity):this() 
        {
            this.Weather.Humidity = humidity;
        }
    }
    
    public class Weather : INotifyPropertyChanged
    {
        #region - Fields -
    
        private string _forecast;        
        private decimal _humidity;        
        
    
        #endregion // Fields
    
        #region - Constructor         -
    
        #endregion // Constructor
    
        #region - Properties -
    
        public string Forecast
        {
            get { return _forecast; }
            set
            {
                if (value == _forecast)
                    return;
    
                _forecast = value;
    
                this.OnPropertyChanged("Forecast");
            }
        }
    
        
        public decimal Humidity
        {
            get { return _humidity; }
            set
            {
                if (value == _humidity)
                    return;
    
                _humidity = value;
    
                this.OnPropertyChanged("Humidity");
                UpdateForeCast();
            }
        }        
    
        #endregion // Properties
    
        #region - Private Methods -
    
        private void UpdateForeCast()
        {
            if (this.Humidity < 0 || this.Humidity > 100)
                this.Forecast = "Unknown";
            else if (this.Humidity >= 70)
                this.Forecast = "High";
            else if (this.Humidity < 40)
                this.Forecast = "Low";
            else 
                this.Forecast = "Average";
        }
    
        #endregion
    
        #region INotifyPropertyChanged Members
    
        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    
        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    
        #endregion // INotifyPropertyChanged Members
    }
