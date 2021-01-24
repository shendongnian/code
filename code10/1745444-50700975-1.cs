    foreach (var scaling in this.preUpdateScaling)
    {
    	await autoScaling.DeregisterScalableTargetAsync(new DeregisterScalableTargetRequest
    	{
    		ResourceId = scaling.ResourceId,
    		ServiceNamespace = ServiceNamespace.Dynamodb,
    		ScalableDimension = ScalableDimension.DynamodbTableWriteCapacityUnits
    	});
    }
