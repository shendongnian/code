            const int minimumAddress = 1;
            const int maximumAddress = 105;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (byte address = minimumAddress; address <= maximumAddress; address++)
            {
                // Debug.WriteLine("checking address " + address);
                var settings = new I2cConnectionSettings(address)
                {
                    BusSpeed = I2cBusSpeed.FastMode,
                    SharingMode = I2cSharingMode.Shared
                };
                using (I2cDevice device = controller.GetDevice(settings))
                {
                    if (device != null)
                    {
                        try
                        {
                            byte[] writeBuffer = new byte[1] { 0 };
                            var result = device.WritePartial(writeBuffer);
                            if (result.Status == I2cTransferStatus.SlaveAddressNotAcknowledged)
                                continue;
                            addresses.Add(address);
                            Debug.WriteLine("Added Address: " + address);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        Debug.WriteLine("device DOES equal null!", address);
                    }
                }
            }
            stopWatch.Start();            
            System.Diagnostics.Debug.WriteLine(stopWatch.ElapsedMilliseconds.ToString());
