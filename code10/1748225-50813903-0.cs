    if(!(message.HasStringPrefix("PREFIX", ref argPos))) { return; }
                var context = new CommandContext(client, message);
                var result = await commands.ExecuteAsync(context, argPos, service);
    
                if(!result.IsSuccess) {
                    //If Failed to execute command due to unknown command
                    if(result.Error.Value.Equals(CommandError.UnknownCommand)) {
                        await message.Channel.SendMessageAsync("blah");
                    } else {
                        //blah
                    }
                }
