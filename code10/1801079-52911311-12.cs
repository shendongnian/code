    public class Data 
    {
        [JsonExtensionData]
        private JObject root;
        private Texture2D texture;
        private char delimiter = ',';
        /// <summary>
        /// Creates a new Data class with the default delimiter.
        /// </summary>
        public Data()
        {
            root = new JObject();
        }
        /// <summary>
        /// Creates a new Data class with a specified delimiter.
        /// </summary>
        /// <param name="delimiter"></param>
        public Data(char delimiter) : this()
        {
            this.delimiter = delimiter;
        }
        /// <summary>
        /// Adds a child node to the specified parent(s) structure, which is split by the delimiter, with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parents"></param>
        public void AddChild(string name, string parents)
        {
            AddChild(name, parents.Split(delimiter));
        }
        /// <summary>
        /// Adds a child node to the specified parent(s) structure with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parents"></param>
        public void AddChild(string name, params string[] parents)
        {
            string lastParent;
            JObject parentObject = ReturnParentObject(out lastParent, parents);
            if (parentObject != null)
            {
                parentObject.Add(name, new JObject());
                ReplaceObject(lastParent, parentObject, parents);
            } else
            {
                string message = "";
                foreach (string parent in parents)
                    message += parent + " -> ";
                throw new ParentNotFoundException($"The parent '{ message.Substring(0, message.LastIndexOf("->")) }' was not found.");
            }
        }
        /// <summary>
        /// Adds a child node to the root structure with the specified name.
        /// </summary>
        /// <param name="name"></param>
        public void AddChild(string name)
        {
            root.Add(name, new JObject());
        }
        /// <summary>
        /// Adds the specified key-value pair to the specified parent(s) structure, which is split by the delimiter.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="parents"></param>
        public void AddKeyWithValue(string key, JToken value, string parents)
        {
            AddKeyWithValue(key, value, parents.Split(delimiter));
        }
        /// <summary>
        /// Adds the specified key-value pair to the specified parent(s) structure.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="parents"></param>
        public void AddKeyWithValue(string key, JToken value, params string[] parents)
        {
            string lastParent;
            JObject parentObject = ReturnParentObject(out lastParent, parents);
            if (parentObject != null)
            {
                parentObject.Add(key, value);
                ReplaceObject(lastParent, parentObject, parents);
            } else
            {
                string message = "";
                foreach (string parent in parents)
                    message += parent + " -> ";
                throw new ParentNotFoundException($"The parent '{ message.Substring(0, message.LastIndexOf("->")) }' was not found.");
            }
        }
        /// <summary>
        /// Adds the specified key-value pair to the root structure.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddKeyWithValue(string key, JToken value)
        {
            root.Add(key, value);
        }
        /// <summary>
        /// Removes the specified key from the specified parent(s) structure, which is split by the delimiter.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parents"></param>
        public void RemoveKey(string key, string parents)
        {
            RemoveKey(key, parents.Split(delimiter));
        }
        /// <summary>
        /// Removes the specified key from the specified parent(s) structure.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parents"></param>
        public void RemoveKey(string key, params string[] parents)
        {
            string lastParent;
            JObject parentObject = ReturnParentObject(out lastParent, parents);
            if (parentObject != null)
            {
                parentObject.Remove(key);
                ReplaceObject(lastParent, parentObject, parents);
            } else
            {
                string message = "";
                foreach (string parent in parents)
                    message += parent + " -> ";
                throw new ParentNotFoundException($"The parent '{ message.Substring(0, message.LastIndexOf("->")) }' was not found.");
            }
        }
        /// <summary>
        /// Removes the specified key from the root structure.
        /// </summary>
        /// <param name="key"></param>
        public void RemoveKey(string key)
        {
            root.Remove(key);
        }
        /// <summary>
        /// Returns if the specified key is contained within the parent(s) structure, which is split by the delimiter.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parents"></param>
        /// <returns></returns>
        public bool HasValue(string key, string parents)
        {
            return HasValue(key, parents.Split(delimiter));
        }
        /// <summary>
        /// Returns if the specified key is contained within the parent(s) structure.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parents"></param>
        /// <returns></returns>
        public bool HasValue(string key, params string[] parents)
        {
            //string lastParent = parents[parents.Length - 1];
            //Array.Resize(ref parents, parents.Length - 1);
            string lastParent;
            JObject parentObject = ReturnParentObject(out lastParent, parents);
            if (parentObject == null)
                return false;
            else if (parentObject == root && parents.Length > 0)
                return false;
            IDictionary<string, JToken> dictionary = parentObject;
            return dictionary.ContainsKey(key);
        }
        /// <summary>
        /// Returns the deepest parent object referenced by the parent(s).
        /// </summary>
        /// <param name="lastParent"></param>
        /// <param name="parents"></param>
        /// <returns></returns>
        private JObject ReturnParentObject(out string lastParent, string[] parents)
        {
            lastParent = null;
            if(parents.Length > 0)
            {
                lastParent = parents[parents.Length - 1];
                Array.Resize(ref parents, parents.Length - 1);
                return GetValueOfKey<JObject>(lastParent, parents);
            }
            return root;
        }
        /// <summary>
        /// Returns the value of the specified key from the specified parent(s) structure, which is split by the delimiter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="parents"></param>
        /// <returns></returns>
        public T GetValueOfKey<T>(string key, string parents)
        {
            return GetValueOfKey<T>(key, parents.Split(delimiter));
        }
        /// <summary>
        /// Returns the value of the specified key from the specified parent(s) structure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="parents"></param>
        /// <returns></returns>
        public T GetValueOfKey<T>(string key, params string[] parents)
        {
            JObject parentObject = null;
            for(int i = 0; i < parents.Length; i++)
                parentObject = GetValueOfKey<JObject>(parents[i].Trim(), parentObject == null ? root : parentObject);
            return GetValueOfKey<T>(key, parentObject == null ? root : parentObject);
        }
        /// <summary>
        /// Returns the value of the specified key from the root structure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetValueOfKey<T>(string key)
        {
            return GetValueOfKey<T>(key, root);
        }
        /// <summary>
        /// Returns the value of the specified key from a given index in the structure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private T GetValueOfKey<T>(string key, JObject index)
        {
            JToken token = index.GetValue(key);
            if (token != null)
                return token.ToObject<T>();
            foreach (var kvp in index)
                if (kvp.Value is JObject)
                {
                    T value = GetValueOfKey<T>(key, (JObject)kvp.Value);
                    if (value != null)
                        return value;
                }
            return default(T);
        }
        /// <summary>
        /// Replaces an object specified by the given key and ensures object is replaced within the correct parent(s), which is split by the delimiter.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="replacement"></param>
        /// <param name="parents"></param>
        public void ReplaceObject(string key, JObject replacement, string parents)
        {
            ReplaceObject(key, root, replacement, parents.Split(delimiter));
        }
        /// <summary>
        /// Replaces an object specified by the given key and ensures object is replaced within the correct parent(s).
        /// </summary>
        /// <param name="key"></param>
        /// <param name="replacement"></param>
        /// <param name="parents"></param>
        public void ReplaceObject(string key, JObject replacement, params string[] parents)
        {
            ReplaceObject(key, root, replacement, parents);
        }
        /// <summary>
        /// Replaces an object specified by the given key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="replacement"></param>
        public void ReplaceObject(string key, JObject replacement)
        {
            ReplaceObject(key, root, replacement);
        }
        /// <summary>
        /// Replaces an object specified by the given key within the structure and updates changes to the root node.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <param name="replacement"></param>
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
                this.root = (JObject)root;
            }
        }
        /// <summary>
        /// Replaces an object specified by the given key within the structure, ensuring object is replaced within the correct parent, and updates changes to the root node.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <param name="replacement"></param>
        /// <param name="parents"></param>
        private void ReplaceObject(string key, JObject index, JObject replacement, params string[] parents)
        {
            foreach (var kvp in index)
                if (kvp.Value is JObject)
                {
                    bool valid = false;
                    foreach (string str in parents)
                        if (str.Trim() == kvp.Key)
                            valid = true;
                    if(valid)
                        ReplaceObject(key, (JObject)kvp.Value, replacement);
                }
            JToken token = index.GetValue(key);
            if (token != null)
            {
                JToken root = token.Root;
                token.Replace(replacement);
                this.root = (JObject)root;
            }
        }
        /// <summary>
        /// Returns the root structure as JSON.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return root.ToString();
        }
        /// <summary>
        /// A ParentNotFoundException details that the supplied parent was not found within the structure.
        /// </summary>
        private class ParentNotFoundException : Exception
        {
            public ParentNotFoundException() { }
            public ParentNotFoundException(string message) : base(message) { }
            public ParentNotFoundException(string message, Exception inner) : base(message, inner) { }
        }
    }
