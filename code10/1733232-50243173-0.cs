    static void Main(string[] args)
        {
            // something like this is coming as the request
            var str = "{\"0\":0.0,\"1\":0.1,\"2\":0.2,\"3\":0.3,\"4\":0.4,\"5\":0.5}";
            // you are getting a JObject, this is the type of "object o", 
            // I am loading one here using the same schema we see in yhour example.
            var jobj = JObject.Load(new JsonTextReader(new StringReader(str)));
            // now we simply need to parse out all the values.
            // option 1:
            // loop over the children as properties.
            var output = new List<float>();
            foreach (var prop in jobj.Children<JProperty>())
            {
                Console.WriteLine($"entry: {prop.Name} value: {prop.Value.ToString()}");
                output.Add(float.Parse(prop.Value.ToString()));
            }
            output.Clear();
            // option 2:
            // convert directly using linq
            float [] outputAsArray = jobj.Children<JProperty>().Select(x => float.Parse(x.Value.ToString())).ToArray();
        }
