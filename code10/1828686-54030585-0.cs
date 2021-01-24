    private async Task Client_MessageReceived(SocketMessage messageParams)
        {
            var message = messageParams as SocketUserMessage;
            var context = new SocketCommandContext(Client, message);
            if (context.Message == null || context.Message.Content == "")
                return;
            if (context.User.IsBot)
                return;
            NoteCommands.CheckIfUserIsMentioned(context);
            var result = await _commands.ExecuteAsync(context, argPos);
        }
