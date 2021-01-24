    public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
            {
                var message = await argument;
                
    			if (message.ChannelId == "telegram")
    			{
    				await context.PostAsync($"Your userid is {message.ChannelData.message.from.id} and your name is {message.ChannelData.message.from.first_name}");
    			}
    			else { 
    				await context.PostAsync($"You said {message.Text}"); //non-telegram stuff
    			}
    			context.Wait(MessageReceivedAsync);
                
            }
