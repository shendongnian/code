    class Foo
    {
        // Initialized elsewhere
        Dictionary<String,String> Fields;
    
        public Int32 this[String key]
        {
            String temp = null;
            Int32 val = 0;
            if (this.Fields.TryGetValue(key, out temp)) {
                Int32.TryParse(temp, out val);
            }
            return val;
        }
    }
