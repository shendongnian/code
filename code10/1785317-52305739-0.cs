     GattReadResult result = await selectedCharacteristic.ReadValueAsync(BluetoothCacheMode.Uncached);
                if (result.Status == GattCommunicationStatus.Success)
                {
                    string formattedResult = FormatValueByPresentation(result.Value, presentationFormat);
                }
