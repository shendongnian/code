    // Create a new message.
    IMessageActivity message = Activity.CreateMessageActivity();
    // Set message object properties
    ..
    ..
    //create a bot connector
    var connector = new ConnectorClient(new Uri(ServiceURL));
    //send message
    await connector.Conversations.SendToConversationAsync((Activity)message);
