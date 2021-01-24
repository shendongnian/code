    private async void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        string ReceivedMessage;
        if (e.Topic == Topic1)
        {
            ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Sensor1Reading.Text = ReceivedMessage;
            });
        }
        else if (e.Topic == Topic2)
        {
            ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Sensor2Reading.Text = ReceivedMessage;
            });
        }
    }
