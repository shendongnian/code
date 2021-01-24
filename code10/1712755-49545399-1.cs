    [TestMethod]
    public async Task Bot_Test_Attachments()
    {
        foreach (var item in RootDialog.dataAtt)
        {
            var preg = item.Key;
            var att = item.Value;
    
            using (ShimsContext.Create())
            {
                var waitCalled = false;
                IMessageActivity message = null;
    
                var target = new RootDialog();
                    
                var activity = new Activity(ActivityTypes.Message)
                {
                    Text = preg,
                    From = new ChannelAccount("id","name"),
                    Recipient = new ChannelAccount("recipid","recipname"),
                    Conversation = new ConversationAccount(false,"id","name")
                };
    
                var awaiter = new Microsoft.Bot.Builder.Internals.Fibers.Fakes.StubIAwaiter<IMessageActivity>()
                {
                    IsCompletedGet = () => true,
                    GetResult = () => activity
                };
    
                var awaitable = new Microsoft.Bot.Builder.Dialogs.Fakes.StubIAwaitable<IMessageActivity>()
                {
                    GetAwaiter = () => awaiter
                };
    
                var context = new Microsoft.Bot.Builder.Dialogs.Fakes.StubIDialogContext();
    
                context.PostAsyncIMessageActivityCancellationToken = (messageActivity, token) => {
                    message = messageActivity;
                    return Task.CompletedTask;
                };
    
                Microsoft.Bot.Builder.Dialogs.Fakes.ShimExtensions.WaitIDialogStackResumeAfterOfIMessageActivity = (stack, callback) =>
                {
                    if (waitCalled) return;
                    waitCalled = true;                        
                    callback(context, awaitable);
                };
                await target.MessageReceivedWithTextAsync(context, awaitable);
    
    
                Assert.AreEqual(att, message.Attachments[0]);
            }
        }
    }
