            if (activity.Type == ActivityTypes.Message)
            {
                var message = activity as IMessageActivity;
                using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                {
                    var botDataStore = scope.Resolve<IBotDataStore<BotData>>();
                    var key = Address.FromActivity(message);
                    ConversationReference r = new ConversationReference();
                    var userData = await botDataStore.LoadAsync(key, BotStoreType.BotUserData, CancellationToken.None);
                    userData.SetProperty("userId", "123");
                    userData.SetProperty("DOB", "some date");
                    await botDataStore.SaveAsync(key, BotStoreType.BotUserData, userData, CancellationToken.None);
                    await botDataStore.FlushAsync(key, CancellationToken.None);
                }
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }
