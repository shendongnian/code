    public string GetSignatureSansModifiers(MethodInfo methodInfo)
    {
	    ParameterInfo[] parameters = methodInfo.GetParameters();
	    return parameters.Length > 0 ? parameters[0].Member.ToString() : $"{methodInfo.ReturnType.ToString()} {methodInfo.Name}()";
    }
    
    public string PrintSignature(MethodInfo methodInfo)
    {
	    StringBuilder sb = new StringBuilder();
    
	    if (methodInfo.IsPrivate)
		    sb.Append("private ");
	    else if (methodInfo.IsPublic)
		    sb.Append("public ");
	    if (methodInfo.IsAbstract)
		    sb.Append("abstract ");
	    if (methodInfo.IsStatic)
		    sb.Append("static ");
	    if (methodInfo.IsVirtual)
		    sb.Append("virtual ");
	    sb.Append(GetSignatureSansModifiers(methodInfo));
	    return sb.ToString();
    }
