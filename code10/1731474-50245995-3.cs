      private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
      {
              //Sending a message nomally
              await context.PostAsync("Hi");
              //Notify the user that the bot is typing
              var typing = context.MakeMessage();
              typing.Type = ActivityTypes.Typing;
              await context.PostAsync(typing);
              //The message you want to delay. 
              //NOTE: Do not use context.PostAsyncWithDelay instead simply call the method.
              await PostAsyncWithDelay(context, "2nd Hi");
      }
