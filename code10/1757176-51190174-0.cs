    public StringBuilder AppendLine(string value)
    {
    	this.Append(value);
    	return this.Append(Environment.NewLine);
    }
