    public string GetSignature(MethodInfo mi)
    {
	if(mi == null)
		return "";
	StringBuilder sb = new StringBuilder();
	
	if(mi.IsPrivate)
		sb.Append("private ");
	else if(mi.IsPublic)
		sb.Append("public ");
	if(mi.IsAbstract)
		sb.Append("abstract ");
	if(mi.IsStatic)
		sb.Append("static ");
	if(mi.IsVirtual)
		sb.Append("virtual ");
	
	sb.Append(mi.ReturnType.Name + " ");
	
	sb.Append(mi.Name + "(");
		
	String[] param = mi.GetParameters()
	  .Select(p => String.Format(
                  "{0} {1}",p.ParameterType.Name,p.Name))
							  .ToArray();
	
	sb.Append(String.Join(", ",param));
	
	sb.Append(")");
		
	return sb.ToString();
}
