    private void OnMessageReceived(Message message) {
        using (var scope = _provider.CreateScope()) {
            var handler = scope.ServiceProvider.GetRequiredService<IHandler>();
            handler.ProcessResourceObject(message);
        }
    }
