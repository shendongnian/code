    public class SillyConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            SillyObject se = new SillyObject();
            foreach (string key in dictionary.Keys)
            {
                switch(key)
                {
                    case "SomeOtherProperty":
                        se.SomeOtherProperty = dictionary[key].ToString();
                        break;
                }
            }
            return se;
        }
    
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            SillyObject se = (SillyObject)obj;
            Dictionary<string, object> objs = new Dictionary<string, object>();
            if (!String.IsNullOrEmpty(se.SomeOtherProperty ))
                objs.Add("SomeOtherProperty", se.SomeOtherProperty);
            return objs;
        }
    
        public override IEnumerable<Type> SupportedTypes { get { return new Type[] { typeof(SillyObject) }; } }
    }
