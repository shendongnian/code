    private static Task SendMessage(string message) {
        return MQTT.RunAsync(message.ToString(), topic);
    }
    public static Task RunAsync(string message) {
        var mqttClient = factory.CreateMqttClient()               
        return mqttClient.ConnectAsync(options);
    }
