            MethodInfo pi = null;
            Type t = obj.GetType(0;
            while (t != typeof(object) && pi == null)
            {
                pi = t.GetMethod("toString",
                    BindingFlags.Instance |
                    BindingFlags.Public | 
                    BindingFlags.DeclaredOnly);
                t = t.BaseType;
            }
            if (pi != null)
            {
                // do smth
            }
