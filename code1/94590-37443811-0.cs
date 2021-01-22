    	private string PrettyPrintGenericTypeName(Type p)
		{
			if (p.IsGenericType) {
				var simpleName = p.Name.Substring(0, p.Name.IndexOf('`'));
				var genericTypeParams = p.GenericTypeArguments.Select(PrettyPrintGenericTypeName).ToList();
				return string.Format("{0}<{1}>", simpleName, string.Join(", ", genericTypeParams));
			} else {
				return p.Name;
			}
		}
