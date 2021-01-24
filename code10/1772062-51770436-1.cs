     public OnlyAttribute(params string[] parameters)
     {
            if (parameters.Length > 4) throw new ArugumentException(nameof(parameters));
    
    		foreach (var param in parameters)
            {
                SetMethod(param);
            }
     }
