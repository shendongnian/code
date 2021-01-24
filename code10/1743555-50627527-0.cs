        public static string Format(string obj,MainInvoiceBind invoice)
        {
            try
            {
                return Regex.Replace(obj, @"{{(?<exp>[^}]+)}}", match =>
                {
                    try
                    {
                        var p = Expression.Parameter(typeof(MainInvoiceBind), "");
                        var e = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p }, null, match.Groups["exp"].Value);
                        return (e.Compile().DynamicInvoke(invoice) ?? "").ToString();
                    }
                    catch
                    {
                        return "Nill";
                    }
                    
                });
            }
            catch
            {
                return string.Empty;
            }
        }
