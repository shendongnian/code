        string output="";
        Type t = o.GetType();
        if (t.GetProperty("Item") != null)
        {
            System.Reflection.PropertyInfo p = t.GetProperty("Item");
            int count = -1;
            if (t.GetProperty("Count") != null && 
                t.GetProperty("Count").PropertyType == typeof(System.Int32))
            {
                count = (int)t.GetProperty("Count").GetValue(o, null);
            }
            if (count > 0)
            {
                object[] index = new object[count];
                for (int i = 0; i < count; i++)
                {
                    object val = p.GetValue(o, new object[] { i });
                    output += RecursiveWorker(val, p, t);
                }
            }
            return output;
        }
}`
