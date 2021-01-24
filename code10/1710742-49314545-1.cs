        private async void SetTime_DS3231(DateTime dt)
        {
            int SlaveAddress = 0x68;
            try
            {
                // Initialize I2C
                var Settings = new I2cConnectionSettings(SlaveAddress);
                Settings.BusSpeed = I2cBusSpeed.StandardMode;
                if (AQS == null || DIS == null)
                {
                    AQS = I2cDevice.GetDeviceSelector("I2C1");
                    DIS = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(AQS);
                }
                using (I2cDevice Device = await I2cDevice.FromIdAsync(DIS[0].Id, Settings))
                {
                    byte write_seconds = decToBcd((byte)dt.Second);
                    byte write_minutes = decToBcd((byte)dt.Minute);
                    byte write_hours = decToBcd((byte)dt.Hour);
                    byte write_dayofweek = decToBcd((byte)dt.DayOfWeek);
                    byte write_day = decToBcd((byte)dt.Day);
                    byte write_month = decToBcd((byte)dt.Month);
                    byte write_year = decToBcd((byte)dt.Year);
                    byte[] write_time = { 0x00, write_seconds, write_minutes, write_hours, write_dayofweek, write_day, write_month, write_year };
                    Device.Write(write_time);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }
        }
        // Convert normal decimal numbers to binary coded decimal
        private byte decToBcd(byte val)
        {
            return (byte)(((int)val / 10 * 16) + ((int)val % 10));
        }
