     public class StringValue : System.Attribute
        {
            private string _value;
            public StringValue(string value)
            {
                _value = value;
            }
            public string Value
            {
                get { return _value; }
            }
            public static string GetStringValue(Enum Flagvalue)
            {
                Type type = Flagvalue.GetType();
                string[] flags = Flagvalue.ToString().Split(',').Select(x => x.Trim()).ToArray();
                List<string> values = new List<string>();
                for (int i = 0; i < flags.Length; i++)
                {
                    FieldInfo fi = type.GetField(flags[i].ToString());
                    StringValue[] attrs =
                       fi.GetCustomAttributes(typeof(StringValue),
                                               false) as StringValue[];
                    if (attrs.Length > 0)
                    {
                        values.Add(attrs[0].Value);
                    }
                }
                return String.Join(",", values);
            }
