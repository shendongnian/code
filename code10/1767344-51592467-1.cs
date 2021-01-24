    void UnpackJson(JToken jobj, int indent)
    {
        if (jobj == null)
            return;
        var name = (jobj as JProperty)?.Name;
        if (name != null)
        {
            Console.Write(new string(' ', indent) + name + " :\n");
            indent += 4;
        }
        foreach (var child in jobj.Children())
        {
            var chname = (child as JProperty)?.Name;
            if (chname != null)
                Console.Write(new string(' ', indent) + chname + " : ");
            var value = (child as JProperty)?.Value;
            if (child.Values().Count() > 1)
            {
                if (chname != null || name != null)
                    Console.WriteLine();
                IEnumerable<JToken> jt = (value is JArray) ? child.Values() : child.Children();
                foreach (var val in jt)
                    UnpackJson(val, indent + 4);
            }
            else
            {
                if (value != null)
                    Console.WriteLine(value);
            }
        }
    }
