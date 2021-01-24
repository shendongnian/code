    private async void CharacteristicReadButton_Click()
        {
        while(true)
        {
                // BT_Code: Read the actual value from the device by using Uncached.
                GattReadResult result = await selectedCharacteristic.ReadValueAsync(BluetoothCacheMode.Uncached);
                if (result.Status == GattCommunicationStatus.Success)
                {
                    string formattedResult = FormatValueByPresentation(result.Value, presentationFormat);
                    rootPage.NotifyUser($"Read result: {formattedResult}", NotifyType.StatusMessage);
                    //string formattedResult = FormatValueByPresentation(result.Value, presentationFormat);
                    //rootPage.NotifyUser($"Read result: {formattedResult}", NotifyType.StatusMessage);
                }
                else
                {
                    rootPage.NotifyUser($"Read failed: {result.Status}", NotifyType.ErrorMessage);
                }
            }
        }
