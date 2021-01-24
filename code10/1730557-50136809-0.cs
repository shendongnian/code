    public void InitSecondTimer(int interval)
    {
        Device.StartTimer(TimeSpan.FromMiliseconds(interval), () =>
        {
            double voltage = 0;
            InputI2C(ADC0, ref voltage); //Read data from I2C devices
            ai0.Text = voltage.ToString(); //ai0 is a Label
            return true; // True = Repeat again, False = Stop the timer
        });
        Debug.WriteLine("Secondtimer inited");
    }
