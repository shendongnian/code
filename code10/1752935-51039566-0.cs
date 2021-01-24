    _client.UserUpdated += async (before, after) =>
    {
       // Check if the user was offline, and now no longer is
       if(before.Status == UserStatus.Offline && after.Status != UserStatus.Offline)
       {
          // Find some channel to send the message to
          var channel = e.Server.FindChannels("Hello-World", ChannelType.Text);
          // Send the message you wish to send
          await channel.SendMessage(after.Name + " has come online!");
       }
    }
