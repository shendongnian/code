    var message = context.ProtocolMessage;
    if (!string.IsNullOrEmpty(message.State))
    {
        context.Properties.Items[OpenIdConnectDefaults.UserstatePropertiesKey] = message.State;
    }
