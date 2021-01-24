    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Web.Script.Serialization;
    
    namespace YourApplicationNamespace    {
        public class JsonApplicationActivityReportConverter : JavaScriptConverter
        {
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                var typeName = (string) dictionary["$type"];
                var typeInfo = Type.GetType(typeName);
                var result = Activator.CreateInstance(typeInfo);
    
                foreach (var property in typeInfo.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (property.CanWrite && dictionary.ContainsKey(property.Name))
                    {
                        property.SetValue(result, dictionary[property.Name]);
                    }
                }
    
                return result;
            }
    
            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                // Reverse the process here if the type is to be used the other direction
            }
    
            public override IEnumerable<Type> SupportedTypes
            {
                get { yield return typeof(JsonApplicationActivityReport); }
            }
        }
    }
