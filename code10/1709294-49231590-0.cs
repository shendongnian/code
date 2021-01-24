      public class MyLuisDialog : LuisDialog<object>
    {
        private static ILuisService GetLuisService()
        {
            var modelId = //Luis modelID;
            var subscriptionKey = //Luis subscription key
            var staging = //whether point to staging or production LUIS
            var luisModel = new LuisModelAttribute(modelId, subscriptionKey) { Staging = staging };
            return new LuisService(luisModel);
        }
        public MyLuisDialog() : base(GetLuisService())
        {
        }
    
     [LuisIntent("KnowledgeBase")]
        public async Task KnowledgeAPICall(IDialogContext context, LuisResult result)
        {
            //your code
        }
