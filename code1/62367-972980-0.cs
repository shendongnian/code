    class Thermostat
    {
        public delegate void TemperatureChangeHandler ( float newTemperature );
    
        public TemperatureChangeHandler OnTemperatureChange { get; set; }
    
        float currentTemperature;
    
        public float CurrentTemperature
        {
            get { return this.currentTemperature; }
            set
            {
                    if (currentTemperature != value)
                    {
                            currentTemperature = value;
    
                            if (this.OnTemperatureChange != null )
                            {
                                    this.OnTemperatureChange.Invoke( value );
                            }
                    }
            }
        }
    }
