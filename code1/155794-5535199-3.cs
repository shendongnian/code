	public static IMyDataServiceContract CreateService()
	{
		var factory = new ChannelFactory<IMyDataServiceContract>("MyServiceName");
		SetDataContractSerializerBehavior(factory.Endpoint.Contract);
		return factory.CreateChannel();
	}
	private static void SetDataContractSerializerBehavior(ContractDescription contractDescription)
	{
		foreach (OperationDescription operation in contractDescription.Operations)
		{
			ReplaceDataContractSerializerOperationBehavior(operation);
		}
	}
	private static void ReplaceDataContractSerializerOperationBehavior(OperationDescription description)
	{
		DataContractSerializerOperationBehavior dcsOperationBehavior =
		description.Behaviors.Find<DataContractSerializerOperationBehavior>();
		if (dcsOperationBehavior != null)
		{
			description.Behaviors.Remove(dcsOperationBehavior);
			description.Behaviors.Add(new CustomDataContractSerializerBehavior(description));
		}
	}
