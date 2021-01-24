    public class ObjectTypesParser
    {
        public ObjectTypes Parse(string json)
        {
            JToken token = JToken.Parse(json);
            var objectsToken = token.First.First.First.FirstOrDefault();
            if (objectsToken is JArray)
            {
                /*
                 Special case - json with an empty array:
                {
                    ""data"": {
                        ""objects"": []
                    }
                }
                */
                return new ObjectTypes();
            }
            // json containing a dictionary:
            ObjectTypes data = JsonConvert.DeserializeObject<ObjectTypes>(json);
            return data;
        }
    }
