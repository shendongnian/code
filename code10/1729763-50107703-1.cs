        private async Task ChoiceReceivedAsync(IDialogContext context, IAwaitable<string> result)
        {
           Activity a = context.Activity as Activity;
            switch (a.Text)
            {
                case "Choice 1":
                    //do stuff
                    break;
                case "Choice 2":
                    //do stuff
                    break;
                default:
                    using (HttpClient client = new HttpClient())
                    {
                        string RequestURI = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/YOUR_MODEL_ID?" +
                                            "subscription-key=YOUR_SUBSCRIPTION_KEY&amp;verbose=true&amp;timezoneOffset=0&amp;q=" +
                                            a.Text;
                        HttpResponseMessage msg = await client.GetAsync(RequestURI);
                        if (msg.IsSuccessStatusCode)
                        {
                            var JsonDataResponse = await msg.Content.ReadAsStringAsync();
                            LUISData luisData = JsonConvert.DeserializeObject<LUISData>(JsonDataResponse);
                        }
                    }
                    break;
            }
            a = a.CreateReply("things");
            await context.PostAsync(a);
        }
