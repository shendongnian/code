    this.preUpdatePolicies = (await autoScaling.DescribeScalingPoliciesAsync(new DescribeScalingPoliciesRequest
	{
		ResourceId = $"table/{this.tableName}",
		ServiceNamespace = ServiceNamespace.Dynamodb,
		ScalableDimension = ScalableDimension.DynamodbTableWriteCapacityUnits
	})).ScalingPolicies;
	this.preUpdateScaling = (await autoScaling.DescribeScalableTargetsAsync(new DescribeScalableTargetsRequest
	{
		ResourceIds = new List<string>() { $"table/{this.tableName}" },
		ServiceNamespace = ServiceNamespace.Dynamodb,
		ScalableDimension = ScalableDimension.DynamodbTableWriteCapacityUnits
	})).ScalableTargets;
