    private static Task SendMessage(string message) {
        return MQTT.RunAsync(message, topic);
    }
    public static async Task RunAsync(string message, string topicName) {
        await this.mqttClient.ConnectAsync(this.options);
        var topicFilter = new TopicFilterBuilder().WithTopic(this._topicname)
            .WithExactlyOnceQoS().Build();
        await mqttClient.SubscribeAsync(topicFilter);
        var applicationMessage = new MqttApplicationMessageBuilder().WithTopic(this._topicname)
           .WithPayload(message).WithAtLeastOnceQoS().Build();
        if (stopSending == false) {
            await mqttClient.PublishAsync(applicationMessage);
        }
            
    }
