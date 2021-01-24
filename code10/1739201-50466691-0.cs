    private async void btnPower_Click(object sender, RoutedEventArgs e)
    {
        var powerState = await client.GetLightStateAsync(selectedLight);
        if (!powerState)
        {
            await client.SetDevicePowerStateAsync(selectedLight, true);
        }
        else
        {
            await client.SetDevicePowerStateAsync(selectedLight, false);
        }
    }
