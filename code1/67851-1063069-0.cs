    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("PropertyX: ");
        sb.AppendLine(this.PropertyX);
			
        // get string from resource file
        sb.Append(Resources.FileName);
        sb.Append(": ");
        sb.AppendLine(this.FileName);
        sb.Append("Number: ");
        sb.AppendLine(this.Number.ToString());
			
        return sb.ToString();
    }
