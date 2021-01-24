        public void CallOptions(IDialogContext context, LuisResult luisResult)
        {
            Process(context, () => luisResult.Query).Wait();
            Process(context, () => "testData").Wait();
        }
        public async Task Process(IDialogContext context, Func<string> query)
        {
            string emoji = query();
            if (emoji.Contains(":)") || emoji.Contains(": )"))
            {
                await context.PostAsync(":)");
            }
        }
