     static void Main(string[] args)
        {
            // something like this is coming as the request
            var str = "{\"0\":0.0,\"1\":0.1,\"2\":0.2,\"3\":0.3,\"4\":0.4,\"5\":0.5}";
            // you are getting a JObject, this is the type of "object o", 
            // I am loading one here using the same schema we see in your example.
            var jobj = JObject.Load(new JsonTextReader(new StringReader(str)));
            // now we simply need to parse out all the values. 
            // Below are 3 options in order from "least amount of built in functions"
            // to most built in usage.
            // personally, I use option 3
            // option 1:
            // loop over the children as properties.
            var output = new List<float>();
            foreach (var prop in jobj.Children<JProperty>())
            {               
                output.Add(float.Parse(prop.Value.ToString()));
            }
            // option 2:
            // convert directly using linq
            float [] outputAsArray = jobj.Children<JProperty>().Select(x => float.Parse(x.Value.ToString())).ToArray();
            
            //option 3 cast and convert using Json.Net
            outputAsArray = jobj.Children<JProperty>().Values<float>().ToArray();
        }
