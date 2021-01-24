    public sealed class LED
    {
        public GpioPinValue ReqPinValue { get; set; }     //Enable/Disable LED
        public bool Flashing { get; set; }      //Does the LED flash
        public GpioPin Pin { get; set; }
        public int flashingPeriod { get; set; } //Period to flash in seconds
    
    
    
        private GpioPinValue value; //Pin value (high/low)
        private int flashCount = 0; //Times we have entered the timer loop
    
    
        public LED(GpioPin pin)
        {
            Pin = pin;
            Flashing = false;
            flashingPeriod = 0;
            ReqPinValue = GpioPinValue.Low;
        }
