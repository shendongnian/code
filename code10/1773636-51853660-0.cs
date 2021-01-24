    private static async Task<ValidateResult> AnswerInquiry(FAQConversation state, object value)
    {
        var asString = value as String;
        var vaConfig = new SmartCareSetting(state.Products);
    
        var result = new ValidateResult() { IsValid = false, Value = value };
    
        if (!string.IsNullOrEmpty(asString))
        {
            var luisService = new LuisService(new LuisModelAttribute(vaConfig.AppID, vaConfig.SubscriptionKey, domain: vaConfig.HostName));
            var luisResult = await luisService.QueryAsync(asString, CancellationToken.None);
            result.Feedback = luisResult.TopScoringIntent.Intent.ToString();
    
            //set IsValid to true
            result.IsValid = true;
        }
        return result;
    }
