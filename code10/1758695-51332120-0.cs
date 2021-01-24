    var message = JsonConvert.DeserializeObject<ConversationReference>(conversationReference).GetPostToBotMessage(); 
        var client = new ConnectorClient(new Uri(message.ServiceUrl));
    
        // Create a scope that can be used to work with state from bot framework.
        using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
        {
            var botData = scope.Resolve<IBotData>();
            await botData.LoadAsync(CancellationToken.None);
    
            // This is our dialog stack.
            var task = scope.Resolve<IDialogTask>();
    
            // Create the new dialog and add it to the stack.
            var dialog = new WhateverDialog();
            // interrupt the stack. This means that we're stopping whatever conversation that is currently happening with the user
            // Then adding this stack to run and once it's finished, we will be back to the original conversation
            task.Call(dialog.Void<object, IMessageActivity>(), null);
            
            await task.PollAsync(CancellationToken.None);
    
            // Flush the dialog stack back to its state store.
            await botData.FlushAsync(CancellationToken.None);        
        }
