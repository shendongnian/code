        public static IEnumerable<object> AsEnumerable(this DataTable dt)
        {
            List<dynamic> result = new List<dynamic>();
            Dictionary<string, object> d;
            foreach (DataRow dr in dt.Rows)
            {
                d = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                    d.Add(dc.ColumnName, dr[dc]);
                result.Add(GetDynamicObject(d));
            }
            return result.AsEnumerable<object>();
        }
        public static dynamic GetDynamicObject(Dictionary<string, object> properties)
        {
            return new MyDynObject(properties);
        }
        public sealed class MyDynObject : DynamicObject
        {
            private readonly Dictionary<string, object> _properties;
            public MyDynObject(Dictionary<string, object> properties)
            {
                _properties = properties;
            }
            public override IEnumerable<string> GetDynamicMemberNames()
            {
                return _properties.Keys;
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (_properties.ContainsKey(binder.Name))
                {
                    result = _properties[binder.Name];
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                if (_properties.ContainsKey(binder.Name))
                {
                    _properties[binder.Name] = value;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
