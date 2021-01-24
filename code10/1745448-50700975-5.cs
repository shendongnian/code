    foreach (var scaling in this.preUpdateScaling)
    {
    	await autoScaling.RegisterScalableTargetAsync(new RegisterScalableTargetRequest
    	{
    		ResourceId = scaling.ResourceId,
    		ServiceNamespace = scaling.ServiceNamespace,
    		ScalableDimension = scaling.ScalableDimension,
    		RoleARN = scaling.RoleARN,
    		MinCapacity = scaling.MinCapacity,
    		MaxCapacity = scaling.MaxCapacity
    	});
    }
    
    foreach (var policy in this.preUpdatePolicies)
    {
    	await autoScaling.PutScalingPolicyAsync(new PutScalingPolicyRequest
    	{
    		ServiceNamespace = policy.ServiceNamespace,
    		ResourceId = policy.ResourceId,
    		ScalableDimension = policy.ScalableDimension,
    		PolicyName = policy.PolicyName,
    		PolicyType = policy.PolicyType,
    		TargetTrackingScalingPolicyConfiguration = policy.TargetTrackingScalingPolicyConfiguration
    	});
    }
