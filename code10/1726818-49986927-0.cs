    while (true)
    {
         var relayConnection = await listener.AcceptConnectionAsync();
         if (relayConnection == null)
         {
             break;
         }
         ProcessMessagesOnConnection(relayConnection, cts);
    }
