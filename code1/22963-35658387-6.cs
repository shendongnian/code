     public static void WriteLine<T>(T obj)
        {
            var t = typeof(T);
            var ifaces = t.GetInterfaces();
            if (ifaces.Any(o => o.Name.StartsWith("ICollection")))
            {
                dynamic lst = t.GetMethod("GetEnumerator").Invoke(obj, null);
                while (lst.MoveNext())
                {
                    WriteLine(lst.Current);
                }
            }            
            else if (t.GetProperties().Any())
            {
                var props = t.GetProperties();
                StringBuilder sb = new StringBuilder();
                foreach (var item in props)
                {
                    sb.Append($"{item.Name}:{item.GetValue(obj, null)}; ");
                }
                sb.AppendLine();
                Console.WriteLine(sb.ToString());
            }
        }
