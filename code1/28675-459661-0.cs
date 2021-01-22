    protected string GetCommandLogString(IDbCommand command)
    {
    	string outputText;
    
    	if (command.Parameters.Count == 0)
    	{
    		outputText = command.CommandText;
    	}
    	else
    	{
    		StringBuilder output = new StringBuilder();
    		output.Append(command.CommandText);
    		output.Append("; ");
    
    		IDataParameter p;
    		int count = command.Parameters.Count;
    		for (int i = 0; i < count; i++)
    		{
    			p = (IDataParameter) command.Parameters[i];
    			output.Append(string.Format("{0} = '{1}'", p.ParameterName, p.Value));
    
    			if (i + 1 < count)
    			{
    				output.Append(", ");
    			}
    		}
    		outputText = output.ToString();
    	}
    	return outputText;
    }
