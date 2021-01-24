    public class Data 
    {
        [JsonProperty]
        private JObject data;
        public Data()
        {
            data = new JObject();
        }
        public void AddChildUnderParent(string parent, string child)
        {
            JObject parentObject = GetValueOfKey<JObject>(parent);
            if (parentObject != null)
            {
                parentObject.Add(child, new JObject());
                ReplaceObject(parent, parentObject);
            }
        }
        public void AddChild(string child)
        {
            data.Add(child, new JObject());
        }
        public void AddKeyWithValueToParent(string parent, string key, JToken value)
        {
            JObject parentObject = GetValueOfKey<JObject>(parent);
            if(parentObject != null)
            {
                parentObject.Add(key, value);
                ReplaceObject(parent, parentObject);
            }
        }
        public void AddKeyWithValue(string key, JToken value)
        {
            data.Add(key, value);
        }
        public void RemoveKeyFromParent(string parent, string key)
        {
            JObject parentObject = GetValueOfKey<JObject>(parent);
            if (parentObject != null)
            {
                parentObject.Remove(key);
                ReplaceObject(parent, parentObject);
            }
        }
        public void RemoveKey(string key)
        {
            data.Remove(key);
        }
        public T GetValueFromParent<T>(string parent, string key)
        {
            JObject parentObject = GetValueOfKey<JObject>(parent);
            if (parentObject != null)
                return parentObject.GetValue(key).ToObject<T>();
            return default;
        }
        public T GetValueOfKey<T>(string key)
        {
            return GetValueOfKey<T>(key, data);
        }
        private T GetValueOfKey<T>(string key, JObject index)
        {
            foreach (var kvp in index)
                if (kvp.Value is JObject)
                {
                    T value = GetValueOfKey<T>(key, (JObject)kvp.Value);
                    if (value != null)
                        return value;
                }
            JToken token = index.GetValue(key);
            if (token != null)
            {
                data = token.Root.ToObject<JObject>();
                return token.ToObject<T>();
            }
            return default;
        }
        public void ReplaceObject(string key, JObject replacement)
        {
            ReplaceObject(key, data, replacement);
        }
        private void ReplaceObject(string key, JObject index, JObject replacement)
        {
            foreach (var kvp in index)
                if (kvp.Value is JObject)
                    ReplaceObject(key, (JObject)kvp.Value, replacement);
            JToken token = index.GetValue(key);
            if (token != null)
            {
                JToken root = token.Root;
                
                token.Replace(replacement);
                data = (JObject)root;
            }
        }
    }
