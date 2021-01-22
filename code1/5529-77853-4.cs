    private string ComputeRegexPattern()
    {
       StringBuilder builder = new StringBuilder();
       if (this._forcePositives)
       {
           builder.Append("([+]|[-])?");
       }
       builder.Append(@"[\d]*((");
       if (!this._useIntegers)
       {
           for (int i = 0; i < this._numericSeparator.Length; i++)
           {
               builder.Append("[").Append(this._numericSeparator[i]).Append("]");
               if ((this._numericSeparator.Length > 0) && (i != (this._numericSeparator.Length - 1)))
               {
                   builder.Append("|");
               }
           }
       }
       builder.Append(@")[\d]*)?");
       return builder.ToString();
    }
