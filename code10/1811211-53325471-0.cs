	await ioTHubModuleClient.SetDesiredPropertyUpdateCallbackAsync(OnDesiredPropertiesUpdate, null);
    static Task OnDesiredPropertiesUpdate(TwinCollection desiredProperties, object userContext)
	{
		try
		{
			Console.WriteLine("Desired property change:");
			Console.WriteLine(JsonConvert.SerializeObject(desiredProperties));
			if (desiredProperties["TemperatureThreshold"]!=null)
				temperatureThreshold = desiredProperties["TemperatureThreshold"];
		}
		catch (AggregateException ex)
		{
			foreach (Exception exception in ex.InnerExceptions)
			{
				Console.WriteLine();
				Console.WriteLine("Error when receiving desired property: {0}", exception);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine();
			Console.WriteLine("Error when receiving desired property: {0}", ex.Message);
		}
		return Task.CompletedTask;
    }
