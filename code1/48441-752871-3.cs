    public static TDelegate CreateNonVirtCall<TOwner, TBase, TDelegate>(Expression<TDelegate> call) where TDelegate : class
    {
        if (! typeof(Delegate).IsAssignableFrom(typeof(TDelegate)))
        {
            throw new InvalidOperationException("TDelegate must be a delegate type.");
        }
    
        var body = call.Body as MethodCallExpression;
    
        if (body.NodeType != ExpressionType.Call || body == null)
        {
            throw new ArgumentException("Expected a call expression", "call");
        }
     
        foreach (var arg in body.Arguments)
        {
            if (arg.NodeType != ExpressionType.Parameter)
            {
                //to support non lambda parameter arguments, you need to add support for compiling all expression types.
                throw new ArgumentException("Expected a constant or parameter argument", "call");
            }
        }
    
        if (body.Object != null && body.Object.NodeType != ExpressionType.Parameter)
        {
            //to support a non constant base, you have to implement support for compiling all expression types.
            throw new ArgumentException("Expected a constant base expression", "call");
        }
    
        var paramMap = new Dictionary<string, int>();
        int index = 0;
        
        foreach (var item in call.Parameters)
        {
            paramMap.Add(item.Name, index++);
        }
    
        Type[] parameterTypes;
    
       
        parameterTypes = call.Parameters.Select(p => p.Type).ToArray();
    
        var m = 
            new DynamicMethod
            (
                "$something_unique", 
                body.Type, 
                parameterTypes,
                typeof(TOwner)
            );
        
        var builder = m.GetILGenerator();
        var callTarget = body.Method;
    
        if (body.Object != null)
        {
            var paramIndex = paramMap[((ParameterExpression)body.Object).Name];
            builder.Emit(OpCodes.Ldarg, paramIndex);
        }
        
        foreach (var item in body.Arguments)
        {
            var param = (ParameterExpression)item;
          
            builder.Emit(OpCodes.Ldarg, paramMap[param.Name]);
        }
    
        builder.EmitCall(OpCodes.Call, FindBaseMethod(typeof(TBase), callTarget), null);
        
        if (body.Type != typeof(void))
        {
            builder.Emit(OpCodes.Ret);
        }
    
        var obj = (object) m.CreateDelegate(typeof (TDelegate));
        return obj as TDelegate;
    }
