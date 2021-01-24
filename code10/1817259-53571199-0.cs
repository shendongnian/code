    public class TweetController
    {
        private static IGpioController _gpio = null;
        private const int PIN = 17;
        public TweetController()
        {
            _gpio = GpioController.Instance;
        }
        public void Tweet(int milliseconds){
            var pin = _gpio.OpenPin(PIN);
            pin.SetDriveMode(GpioPinDriveMode.Output); // open the gpio pin before writing or unauthorizedexception occurs
            pin.Write(GpioPinValue.High);
            Thread.Sleep(milliseconds);
            pin.Write(GpioPinValue.Low);
        }
    }
