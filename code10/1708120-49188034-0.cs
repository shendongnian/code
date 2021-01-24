    if (context.IsAsync())
    {
    	dynamic member = context.ServiceMethod.ReturnType.GetMember("Result")[0];
    	dynamic temp = System.Convert.ChangeType(result, member.PropertyType);
    	context.ReturnValue = System.Convert.ChangeType(Task.FromResult(temp), context.ServiceMethod.ReturnType);
    }
