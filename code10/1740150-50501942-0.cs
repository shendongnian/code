    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
		if (reader.TokenType == JsonToken.Null)
			return null;				
		var jo = JObject.Load(reader);
		var typeValue = (string)jo.GetValue("Type", StringComparison.OrdinalIgnoreCase);			
		Models.CRMIntegrationDirectPromptType integrationPromptType;
		if (!Enum.TryParse(typeValue, out integrationPromptType))
		{
			integrationPromptType = Models.CRMIntegrationDirectPromptType.Label;
		}
		
		CreateCRMIntegrationDirectPromptBaseBindingModel model;
		switch (integrationPromptType)
		{
			case Models.CRMIntegrationDirectPromptType.MobilePhone:
				model = new Models.CreateCRMIntegrationPromptMobilePhoneBindingModel();
				break;
			
			case Models.CRMIntegrationDirectPromptType.Label:
				model = new Models.CreateCRMIntegrationPromptLabelBindingModel();
				break;
			
			// Add other cases as required.
			
			default:
				throw new JsonSerializationException(typeValue);
		}
		serializer.Populate(jo.CreateReader(), model);
		return model;
    }
