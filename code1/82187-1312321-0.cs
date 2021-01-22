     public static class MethodInfoExtension
            {
                public static string MethodSignature(this MethodInfo mi)
                {
                    String[] param = mi.GetParameters()
                                  .Select(p => String.Format("{0} {1}",p.ParameterType.Name,p.Name))
                                  .ToArray();
    
                string signature = String.Format("{0} {1}({2})", mi.ReturnType.Name, mi.Name, String.Join(",", param));
                return signature;
            }
        }
        var methods = typeof(string).GetMethods().Where( x => x.Name.Equals("Compare"));
        
        foreach(MethodInfo item in methods)
        {
            Console.WriteLine(item.MethodSignature());
        }
