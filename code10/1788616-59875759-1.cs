public async Task<bool> ConnectAsync()
{
    return await Task.Run(() =>
    {
        Log($"Connecting to {MqttSettings.Host}:{MqttSettings.Port}");
        try
        {
            var configuration = new MqttConfiguration();
            configuration.Port = SolaceSettings.Port;
            _mqttClient = MqttClient.CreateAsync(MqttSettings.Host, configuration).Result;
            _sessionState = _mqttClient.ConnectAsync(new MqttClientCredentials(MqttSettings.MqttClientId, MqttSettings.Username, MqttSettings.Password)).Result;
            Log("Connected.");
            return true;
        }
        catch (Exception ex)
        {
            Log($"Could not connect. {ex}");
            return false;
        }
    });
}
However that won't fix the root cause for not being able to connect. For me there were two main issues:
 - Don't run in simulator, use a real device (at least if your Mac is behind a proxy / firewall).
 - <strike>I specified a random client ID. After configuring a client ID on the broker and using the same in the client, it worked.</strike> Update: Obviously this is wrong and was not needed. The client ID entry is automatically generated when connecting with a new ID.
