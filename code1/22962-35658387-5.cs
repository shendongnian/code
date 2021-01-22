     var ifaces = t.GetInterfaces();
            if (ifaces.Any(o => o.Name.StartsWith("ICollection")))
            {
                dynamic lst = t.GetMethod("GetEnumerator").Invoke(obj, null);
                while (lst.MoveNext())
                {
                    WriteLine(lst.Current);
                }
            }   
