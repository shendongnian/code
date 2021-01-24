    public void OnTimedEvent(object sender, MicroLibrary.MicroTimerEventArgs timerEventArgs)
    {
    
        byte[] readBuf = new byte[2];
        I2CDevice.ReadI2C(chan, readBuf); //read voltage data from analog to digital converter
        sbyte high = (sbyte)readBuf[0];
        int mvolt = high * 16 + readBuf[1] / 16;
        val = mvolt / 204.7 + inputOffset;
        val = val / I2CADDA.MainPage.gainFactor / I2CADDA.MainPage.gainVD; 
    }
