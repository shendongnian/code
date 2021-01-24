    public static string GetItemRate(JObject obj, string timePeriodText, string itemDescriptionText)
    {
        return obj.SelectToken("GrowthRates")
                  .First(jo => (string)jo.SelectToken("ComparedToFinancialStatementHeader.TimePeriodText.txt") == timePeriodText)
                  .SelectToken("GrowthRateItem")
                  .First(jo => (string)jo.SelectToken("ItemDescriptionText.txt") == itemDescriptionText)
                  .SelectToken("ItemRate")
                  .Value<string>();
    }
