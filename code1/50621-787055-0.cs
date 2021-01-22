    foreach (PropertyInfo p in props)
        {
            // We need to distinguish between indexed properties and parameterless properties
            if (p.GetIndexParameters().Length == 0)
            {
                // This is the value of the property
                Object v = p.GetValue(t, null);
                // If it implements IList<> ...
                if (v != null && v.GetType().GetInterface("IList`1") != null)
                {
                    // ... then make the recursive call:
                    typeof(YourDeclaringClassHere).GetMethod("PrintListProperties").MakeGenericMethod(v.GetType().GetInterface("IList`1").GetGenericArguments()).Invoke(null, new object[] { v, indent + "  " });
                }
                Console.WriteLine(indent + "  {0} = {1}", p.Name, v);
            }
            else
            {
                Console.WriteLine(indent + "  {0} = <indexed property>", p.Name);
            }
        }    
