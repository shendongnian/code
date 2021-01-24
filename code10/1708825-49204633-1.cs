    public async Task Connect()
    {
        var gpioController = await GpioController.GetDefaultAsync();
        try
        {
            _openPin = gpioController.OpenPin(_doorMotorOpenPin);
            _closePin = gpioController.OpenPin(_doorMotorClosePin);
        }
    }
