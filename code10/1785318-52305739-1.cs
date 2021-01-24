    private string FormatValueByPresentation(IBuffer buffer, GattPresentationFormat format)
            {
                // BT_Code: For the purpose of this sample, this function converts only UInt32 and
                // UTF-8 buffers to readable text. It can be extended to support other formats if your app needs them.
                byte[] data;
                CryptographicBuffer.CopyToByteArray(buffer, out data);
                if (format != null)
                {
                    if (format.FormatType == GattPresentationFormatTypes.UInt32 && data.Length >= 4)
                    {
                        return BitConverter.ToInt32(data, 0).ToString();
                    }
                    else if (format.FormatType == GattPresentationFormatTypes.Utf8)
                    {
                        try
                        {
                            return Encoding.UTF8.GetString(data);
                        }
                        catch (ArgumentException)
                        {
                            return "(error: Invalid UTF-8 string)";
                        }
                    }
                    else
                    {
                        // Add support for other format types as needed.
                        return "Unsupported format: " + CryptographicBuffer.EncodeToHexString(buffer);
                    }
                }
                else if (data != null)
                {
                    // We don't know what format to use. Let's try some well-known profiles, or default back to UTF-8.
                    if (selectedCharacteristic.Uuid.Equals(GattCharacteristicUuids.HeartRateMeasurement))
                    {
                        try
                        {
                            return "Heart Rate: " + ParseHeartRateValue(data).ToString();
                        }
                        catch (ArgumentException)
                        {
                            return "Heart Rate: (unable to parse)";
                        }
                    }
                    else if (selectedCharacteristic.Uuid.Equals(GattCharacteristicUuids.BatteryLevel))
                    {
                        try
                        {
                            // battery level is encoded as a percentage value in the first byte according to
                            // https://www.bluetooth.com/specifications/gatt/viewer?attributeXmlFile=org.bluetooth.characteristic.battery_level.xml
                            return "Battery Level: " + data[0].ToString() + "%";
                        }
                        catch (ArgumentException)
                        {
                            return "Battery Level: (unable to parse)";
                        }
                    }
                    // This is our custom calc service Result UUID. Format it like an Int
                    else if (selectedCharacteristic.Uuid.Equals(Constants.ResultCharacteristicUuid))
                    {
                        return BitConverter.ToInt32(data, 0).ToString();
                    }
                    // No guarantees on if a characteristic is registered for notifications.
                    else if (registeredCharacteristic != null)
                    {
                        // This is our custom calc service Result UUID. Format it like an Int
                        if (registeredCharacteristic.Uuid.Equals(Constants.ResultCharacteristicUuid))
                        {
                            return BitConverter.ToInt32(data, 0).ToString();
                        }
                    }
                    else
                    {
                        try
                        {
                            return "Unknown format: " + Encoding.UTF8.GetString(data);
                        }
                        catch (ArgumentException)
                        {
                            return "Unknown format";
                        }
                    }
                }
                else
                {
                    return "Empty data received";
                }
                return "Unknown format";
            }
