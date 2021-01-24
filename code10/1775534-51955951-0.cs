        public async Task ClickHandleAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            try
            {
                string someValue = "unknown";
                if (message.Value != null)
                {
                    // Got an Action Submit
                    dynamic value = message.Value;
                    string s = value.ToString();
                    Trace.WriteLine(s);
                    someValue = value.SomeType;
                }
                else
                    Trace.TraceInformation("There is no value");
                //string data = message.ChannelData.ToString();
                //Trace.WriteLine(data);
                //Trace.TraceInformation("stringify message");
                //string json = new JavaScriptSerializer().Serialize(message);
                //Trace.WriteLine(json);
                await context.PostAsync("Thanks for the click! SomeType is " + someValue);
                context.Wait(MessageReceivedAsync);
            }
            catch (Exception e)
            {
                Trace.TraceInformation(e.ToString());
            }
        }
        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            if (message.Text == "show card")
            {
                var response = context.MakeMessage();
                if (response.Attachments == null)
                    response.Attachments = new List<Attachment>();
                AdaptiveCard card = new AdaptiveCard();
                card.Body.Add(new AdaptiveTextBlock()
                {
                    Text = "This is a test",
                    Weight = AdaptiveTextWeight.Bolder,
                    Size = AdaptiveTextSize.Medium
                });
                card.Actions.Add(new AdaptiveSubmitAction()
                {
                    Title = "Click Me",
                    Id = "12345678",
                    DataJson = "{ \"SomeType\": \"SomeData\" }"
                });
                Attachment attachment = new Attachment()
                {
                    ContentType = AdaptiveCard.ContentType,
                    Content = card,
                    Name = "MyCard"
                };
                response.Attachments.Add(attachment);
                await context.PostAsync(response);
                context.Wait(ClickHandleAsync);
            }
