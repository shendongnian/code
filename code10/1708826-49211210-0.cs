            if (BtnTempFan.IsChecked == false)
            {
                TogglePin(TempFan, TempFan_PIN, BtnTempFan, GpioPinValue.High);
            }
            if (BtnTempFan.IsChecked == true)
            {
                TogglePin(TempFan, TempFan_PIN, BtnTempFan, GpioPinValue.Low);
            }
        }
        private void InitializePins()
        {
            var gpio = GpioController.GetDefault();
            //   Show an error if there is no GPIO controller
            
            if (gpio == null)
            {
                TempFan = null;
                LblError.Text = "We can't find the controller on the device";
                LblError.Visibility = Visibility.Visible;
                return;
            }
            
            TempFan = gpio.OpenPin(TempFan_PIN);
            TempFan.SetDriveMode(GpioPinDriveMode.Output);
        }
        private void TogglePin(GpioPin PinName, int PinNumber, ToggleButton Name, GpioPinValue value)
        {
            int pinnumber = PinNumber;
            GpioPinValue pinvalue;
            pinvalue = value;
            PinName.Write(pinvalue);
        }
