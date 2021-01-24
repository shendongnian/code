	public static void InitializeJsonSerializer()
	{
		JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
		{
			MissingMemberHandling = MissingMemberHandling.Error,
			Error = ErrorHandler,
		};
		void ErrorHandler(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
		{
			if (e.ErrorContext.Error.Message.StartsWith("Could not find member "))
			{
				// do something...
				
				// hide the error
				e.ErrorContext.Handled = true;
			}
		}
	}
