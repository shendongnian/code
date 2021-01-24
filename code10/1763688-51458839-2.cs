    static void Main(string[] args)
    {
        var json = "{\"range\":[{\"num\":0},{\"num\":1},{\"num\":2},{\"num\":3},{\"num\":4},{\"num\":5},{\"num\":6},{\"num\":7},{\"num\":8},{\"num\":9}],\"friends\":[{\"id\":0,\"name\":\"Christian Cruz\"},{\"id\":1,\"name\":\"Hunter Moon\"},{\"id\":2,\"name\":\"Holden Gentry\"}]}";
        JObject obj = JObject.Parse(json);
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
        UnpackJson(obj, 0);
        Console.Read();
    }
