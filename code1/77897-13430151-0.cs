        using System.Collections.Specialized;
        
        private ListDictionary  g_Attributes = new ListDictionary();
        public ListDictionary Attributes
        {
            get { return this.g_Attributes; }
        }
        public string GetAttribute(string name)
		{
			if (HasAttribute(name))
				return (string) g_Attributes[name];
			else
				return null;
		}
        public bool HasAttribute(string name)
		{
			return this.Attributes.Contains(name);
		}
        using System.Collection.Generic;
        
        private Dictionary<string, object> g_Attributes = new Dictionary<string, object>();
        public Dictionary<string, object> Attributes
        {
            get { return this.g_Attributes; }
        }
        public string GetAttribute(string name)
        {
            if (HasAttribute(name))
            {
                return g_Attributes[name].ToString();
            }
            else
            {
                return null;
            }
        }
        public bool HasAttribute(string name)
        {
		return this.Attributes.ContainsKey(name);
        }
