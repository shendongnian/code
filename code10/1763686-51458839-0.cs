    static void Main(string[] args)
    {
        var json = "{\"range\":[{\"num\":0},{\"num\":1},{\"num\":2},{\"num\":3},{\"num\":4},{\"num\":5},{\"num\":6},{\"num\":7},{\"num\":8},{\"num\":9}],\"friends\":[{\"id\":0,\"name\":\"Christian Cruz\"},{\"id\":1,\"name\":\"Hunter Moon\"},{\"id\":2,\"name\":\"Holden Gentry\"}]}";
        JObject obj = JObject.Parse(json);
        void UnpackJson(JToken jobj, int indent)
        {
            if (jobj == null)
                return;
            foreach (JToken child in jobj.Children())
            {
                Console.Write(new string(' ', indent) + (child as JProperty)?.Name + " : ");
                if (child.Values().Count() > 1)
                {
                    Console.WriteLine();
                    foreach (var value in child.Values())
                        UnpackJson(value, 4);
                }
                else
                    Console.WriteLine((child as JProperty)?.Value);                   
            }
        }
        UnpackJson(obj, 0);
        Console.Read();
    }
