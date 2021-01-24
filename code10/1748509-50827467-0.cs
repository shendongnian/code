    public class BlinkActivity : Activity, IGpioCallback
    {
        ~~~~
        button.RegisterGpioCallback(new Handler(), this);
        ~~~~
        // remove the Task.Run block
        public OnGpioEdge(Gpio gpio)
        {
            Log.Debug("SO", gpio.Value.ToString());
        }
       
        ~~~~
    }
    
