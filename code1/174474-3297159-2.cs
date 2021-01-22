    public String GetMethodParameterArray()
        {
            var output = new StringBuilder();
            output.AppendLine();
            Type t = typeof(API);
            foreach (var mi in t.GetMethods())
            {
                    var argsLine = new StringBuilder();
                    bool isFirst = true;
                    argsLine.Append("object[] args = {");
                    var args = mi.GetParameters();
                   
                    foreach (var pi in args)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            argsLine.Append(", ");
                        }
                        argsLine.AppendFormat("{0}", pi.Name);
                    }
                    argsLine.AppendLine("};"); //close object[] initialiser
                    output.AppendLine(argsLine.ToString());
                    output.AppendFormat("Log(\"{0}\",args);", mi.Name);
                    output.AppendLine();
                    output.AppendLine();
                }
            return output.ToString();
        }
