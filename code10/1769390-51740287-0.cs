    [Serializable]
    public class MyLuisDialog : LuisDialog<object>
    {
        public MyLuisDialog() : base(new LuisService(new LuisModelAttribute("xxxxxxx", 
            "xxxxxxx", 
            domain: "westus.api.cognitive.microsoft.com")))
        {
        }
    
    
        //modify Luis request to make it return all intents instead of just the topscoring intent
        protected override LuisRequest ModifyLuisRequest(LuisRequest request)
        {
            request.Verbose = true;
            return request;
        }
    
        protected override async Task DispatchToIntentHandler(IDialogContext context, IAwaitable<IMessageActivity> item, IntentRecommendation bestIntent, LuisResult result)
        {
                
            if (bestIntent.Intent == "FindFood" || bestIntent.Intent == "BuyFood")
            {
                if (result.Intents[0].Score - result.Intents[1].Score < 0.1)
                {
                    bestIntent.Intent = "FindOrBuyFood";
                    bestIntent.Score = 1;
                }
            }
    
            await base.DispatchToIntentHandler(context, item, bestIntent, result);
        }
    
        [LuisIntent("Greeting")]
        public async Task GreetingIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }
    
        //...
        //other intent handlers
        //...
    
        [LuisIntent("FindFood")]
        [LuisIntent("BuyFood")]
        public async Task FoodIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }
    
        [LuisIntent("FindOrBuyFood")]
        public async Task FindOrBuyFoodIntent(IDialogContext context, LuisResult result)
        {
            var food = "food";
    
            if (result.Entities.Count() > 0)
            {
                food = result.Entities[0].Entity;
            }
    
            List<string> options = new List<string>() { $"Find {food}", $"Buy {food}" };
    
            PromptDialog.Choice(
                context: context,
                resume: ChoiceReceivedAsync,
                options: options,
                prompt: "Hi. Please Select one option :",
                retry: "Please try again.",
                promptStyle: PromptStyle.Auto
                );
        }
    
        private async Task ChoiceReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var option = await result;
    
            //your code logic here
    
            await context.PostAsync($"You selected the '{option}'");
    
            context.Wait(MessageReceived);
        }
    
        private async Task ShowLuisResult(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached {result.Intents[0].Intent} intent.");
            context.Wait(MessageReceived);
        }
    } 
