    public static class ScenarioContextExtensions
    {
        public static UpdateResponseType GetUpdateReponse(this ScenarioContext context)
        {
            return context["updateResponse"] as UpdateResponseType;
        }
        public static void SetUpdateResponse(this ScenarioContext context, UpdateResponseType updateResponse)
        {
            return context["updateResponse"] = updateResponse;
        }
    }
