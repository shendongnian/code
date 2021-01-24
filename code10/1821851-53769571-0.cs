    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using TelemeterFactory;
    
    namespace ConsoleTelemeter
    {
        /// <summary>Generate a CSharp Telemeter that calls Console.WriteLine as its output.</summary>
        public class Factory : FactoryBase
        {
            public override string[] GenerateSource(SourceGenerationOptions options)
            {
                var generatedClassName = options.Type.Name + "_" + options.FactoryOptions.ClassName;
    
                var text = this.CSharpTemplate()
                    .Replace("<codeGenerationTool>", $"{nameof(ConsoleTelemeter)} {Assembly.GetExecutingAssembly().GetName().Version} {DateTimeOffset.UtcNow:yyyy-MM-dd HH:mm:ss zzz}")
                    .Replace("<generatedNamespace>", options.FactoryOptions.Namespace)
                    .Replace("<generatedClassName>", generatedClassName)
                    .Replace("<interfaceImplemented>", options.Type.FullName)
                    .Replace("//<privateFields>", "private const string Null = \"<null>\";")
                    .Replace("//<publicMethodImplementations>", Methods(options.Methods))
                    .Replace("\t", "    ")
                    ;
    
                return new[] { text, $"{options.FactoryOptions.Namespace}.{generatedClassName}" };
            }
    
            private string Methods(IReadOnlyList<MethodInfo> methods)
            {
                var sb = new StringBuilder(4096);
                foreach (var method in methods)
                {
                    // method start
                    sb.AppendFormat("\n\t\tpublic {0} {1} (", method.ReturnType, method.Name);
                    var comma = string.Empty;
                    foreach (ParameterInfo parameter in method.GetParameters())
                    {
                        sb.AppendFormat("{0}{1} {2}", comma, parameter.ParameterType, parameter.Name);
                        comma = ", ";
                    }
                    sb.Append(") {\n");
    
                    sb.Append("\t\t\tvar result = $\"{DateTimeOffset.UtcNow:yyyy-MM-dd HH:mm:ss.ffffff} ");
                    sb.Append("{nameof(");
                    sb.Append(method.Name);
                    sb.Append(")}: ");
    
                    comma = string.Empty;
                    foreach (ParameterInfo parameter in method.GetParameters())
                    {
                        var t = parameter.ParameterType;
                        sb.AppendFormat("{0}{{nameof({1})}}={{", comma, parameter.Name);
    
                        // special case for boolean parameters to be coerced to strings below.  Not strictly necessary for this Telemeter but show how one could do it if necessary.
                        sb.AppendFormat("{1}{0}", parameter.Name, t == typeof(Boolean) ? "(" : string.Empty);
    
                        if (t == typeof(string))
                        {
                            sb.Append(" ?? Null");
                        }
                        else if (t == typeof(Int32) 
                             || t == typeof(float) 
                             || t == typeof(double)
                             || t == typeof(Int64)
                             || t == typeof(decimal)
                             || t == typeof(Int16))
                        {
                            sb.Append(":#0");
                        }
                        else if (t.BaseType == typeof(Enum))
                        {
                            sb.Append(":D");
                        }
                        else if (t == typeof(Boolean))
                        {
                            sb.Append("? \"1\" : \"0\")");
                        }
                        else
                        {
                            sb.Append(".ToString() ?? Null");
                        }
    
                        sb.Append("}");
                        comma = ",";
                    }
    
                    sb.Append("\";\n\t\t\treturn result;\n");
    
                    // method end
                    sb.Append("\t\t}\n");
                }
    
                return sb.ToString();
            }
        }
    }
