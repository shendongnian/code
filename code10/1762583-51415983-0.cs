    public void InitStatusLED()
    {
        gpioController = GPIO.InitGPIO();
        if (gpioController == null)
        {
            Debug.WriteLine("Failed to find GPIO Controller!");
            //TODO proper error handling although this should never happen
        }
        else
        {
            //Setup the default parameters for the LEDS (ie flashing or non-flashing)
            RunLed = new LED(GPIO.InitOutputPin(gpioController, RUN_LED));
            IOLed = new LED(GPIO.InitOutputPin(gpioController,IO_LED));
            //And so on
