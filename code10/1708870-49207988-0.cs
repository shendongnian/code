    private async Task<bool> StartCount() {
        if (TicksLeftPin.Read() == GpioPinValue.High && TicksRightPin.Read() == GpioPinValue.High)
            {
                if (CwCcwPinLeft.Read() == GpioPinValue.High && CwCcwPinRight.Read() == GpioPinValue.Low)
                { // MOVING ON A STRAIGHT LINE
                    LeftMotor_TickCounter++;
                    RightMotor_TickCounter++;
                }
                else if (CwCcwPinLeft.Read() == GpioPinValue.High && CwCcwPinRight.Read() == GpioPinValue.High)
                { // ROTATING TO RIGHT
                    LeftMotor_TickCounter++;
                    RightMotor_TickCounter--;
                }
                else if (CwCcwPinLeft.Read() == GpioPinValue.Low && CwCcwPinRight.Read() == GpioPinValue.High)
                { // MOVING BACKWARDS
                    LeftMotor_TickCounter--;
                    RightMotor_TickCounter--;
                }
                else
                { // ROTATING TO LEFT
                    LeftMotor_TickCounter--;
                    RightMotor_TickCounter++;
                }
            }
            else if (TicksLeftPin.Read() == GpioPinValue.High && TicksRightPin.Read() == GpioPinValue.Low)
            {
                if (CwCcwPinLeft.Read() == GpioPinValue.High)
                {
                    LeftMotor_TickCounter++;
                }
                else
                {
                    LeftMotor_TickCounter--;
                }
            }
            else if (TicksLeftPin.Read() == GpioPinValue.Low && TicksRightPin.Read() == GpioPinValue.High)
            {
                 if (CwCcwPinRight.Read() == GpioPinValue.Low)
                {
                    RightMotor_TickCounter++;
                }
                else
                {
                    RightMotor_TickCounter--;
                }
            }
            CounterLabelLeft.Text = LeftMotor_TickCounter.ToString();
            CounterLabelRight.Text = RightMotor_TickCounter.ToString();
            return true;
    }            
