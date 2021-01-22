    public static void WriteLine<T>(T obj)
        {
            var t = typeof(T);
            var props = t.GetProperties();
            StringBuilder sb = new StringBuilder();
            foreach (var item in props)
            {
                sb.Append($"{item.Name}:{item.GetValue(obj,null)}; ");
            }
            sb.AppendLine();
            Console.WriteLine(sb.ToString());
        }
