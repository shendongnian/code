    public static string Dump(object o, string name = "", int depth = 3)
    {
        try
        {
            var leafprefix = (string.IsNullOrWhiteSpace(name) ? name : name + " = ");
            if (null == o) return leafprefix + "null";
            
            var t = o.GetType();
            if (depth-- < 1 || t == typeof (string) || t.IsValueType)
                return  leafprefix + o;
            var sb = new StringBuilder();
            var enumerable = o as IEnumerable;
            if (enumerable != null)
            {
                name = (name??"").TrimEnd('[', ']') + '[';
                var elements = enumerable.Cast<object>().Select(e => Dump(e, "", depth)).ToList();
                var arrayInOneLine = elements.Count + "] = {" + string.Join(",", elements) + '}';
                if (!arrayInOneLine.Contains(Environment.NewLine)) // Single line?
                    return name + arrayInOneLine;
                var i = 0;
                foreach (var element in elements)
                {
                    var lineheader = name + i++ + ']';
                    sb.Append(lineheader).AppendLine(element.Replace(Environment.NewLine, Environment.NewLine+lineheader));
                }
                return sb.ToString();
            }
            foreach (var f in t.GetFields())
                sb.AppendLine(Dump(f.GetValue(o), name + '.' + f.Name, depth));
            foreach (var p in t.GetProperties())
                sb.AppendLine(Dump(p.GetValue(o, null), name + '.' + p.Name, depth));
            if (sb.Length == 0) return leafprefix + o;
            return sb.ToString().TrimEnd();
        }
        catch
        {
            return name + "???";
        }
    }
