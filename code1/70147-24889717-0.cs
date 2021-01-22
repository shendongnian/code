    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Script.Serialization;
    using System.Reflection;
    public class JsonConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            List<MemberInfo> members = new List<MemberInfo>();
            members.AddRange(type.GetFields());
            members.AddRange(type.GetProperties().Where(p => p.CanRead && p.CanWrite && p.GetIndexParameters().Length == 0));
            
            object obj = Activator.CreateInstance(type);
            foreach (MemberInfo member in members)
            {
                JsonPropertyAttribute jsonProperty = (JsonPropertyAttribute)Attribute.GetCustomAttribute(member, typeof(JsonPropertyAttribute));
                
                if (jsonProperty != null && dictionary.ContainsKey(jsonProperty.Name))
                {
                    SetMemberValue(serializer, member, obj, dictionary[jsonProperty.Name]);
                }
                else if (dictionary.ContainsKey(member.Name))
                {
                    SetMemberValue(serializer, member, obj, dictionary[member.Name]);
                }
                else
                {
                    KeyValuePair<string, object> kvp = dictionary.FirstOrDefault(x => string.Equals(x.Key, member.Name, StringComparison.InvariantCultureIgnoreCase));
                    if (!kvp.Equals(default(KeyValuePair<string, object>)))
                    {
                        SetMemberValue(serializer, member, obj, kvp.Value);
                    }
                }
            }
            return obj;
        }
        private void SetMemberValue(JavaScriptSerializer serializer, MemberInfo member, object obj, object value)
        {
            if (member is PropertyInfo)
            {
                PropertyInfo property = (PropertyInfo)member;                
                property.SetValue(obj, serializer.ConvertToType(value, property.PropertyType), null);
            }
            else if (member is FieldInfo)
            {
                FieldInfo field = (FieldInfo)member;
                field.SetValue(obj, serializer.ConvertToType(value, field.FieldType));
            }
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            Type type = obj.GetType();
            List<MemberInfo> members = new List<MemberInfo>();
            members.AddRange(type.GetFields());
            members.AddRange(type.GetProperties().Where(p => p.CanRead && p.CanWrite && p.GetIndexParameters().Length == 0));
            
            Dictionary<string, object> values = new Dictionary<string, object>();
            foreach (MemberInfo member in members)
            {
                JsonPropertyAttribute jsonProperty = (JsonPropertyAttribute)Attribute.GetCustomAttribute(member, typeof(JsonPropertyAttribute));
                if (jsonProperty != null)
                {
                    values[jsonProperty.Name] = GetMemberValue(member, obj);
                }
                else
                {
                    values[member.Name] = GetMemberValue(member, obj);
                }
            }
            return values;
        }
        private object GetMemberValue(MemberInfo member, object obj)
        {
            if (member is PropertyInfo)
            {
                PropertyInfo property = (PropertyInfo)member;
                return property.GetValue(obj, null);
            }
            else if (member is FieldInfo)
            {
                FieldInfo field = (FieldInfo)member;
                return field.GetValue(obj);
            }
            return null;
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get 
            {
                return new[] { typeof(DataObject) };
            }
        }
    }
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class JsonPropertyAttribute : Attribute
    {
        public JsonPropertyAttribute(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
            set;
        }
    }
