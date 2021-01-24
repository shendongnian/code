        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        using Newtonsoft.Json.Serialization;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Reflection;
        public interface ISerializeSelectedPropertiesOnly {
            bool ShouldSerialize(string propertyName);
        }
        public class Person : ISerializeSelectedPropertiesOnly {
            public int Id;
            public string FirstName;
            public string LastName;
            public HashSet<string> _propertiesToSerialize;
            public bool ShouldSerialize(string propertyName) {
                return _propertiesToSerialize?.Contains(propertyName, StringComparer.OrdinalIgnoreCase) ?? true;
            }
        }
        public class SelectedPropertiesContractResolver : CamelCasePropertyNamesContractResolver {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
                if (typeof(ISerializeSelectedPropertiesOnly).IsAssignableFrom(property.DeclaringType)) {
                    property.ShouldSerialize = instance => ((ISerializeSelectedPropertiesOnly)instance).ShouldSerialize(property.PropertyName);
                }
                return property;
            }
        }
        class Program {
            static void Main(string[] args) {
                var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
                person._propertiesToSerialize = new HashSet<string> { "Id", "FirstName" };
                var serializer = new JsonSerializer {
                    ContractResolver = new SelectedPropertiesContractResolver()
                };
                string json1 = JObject.FromObject(person, serializer).ToString();
                person._propertiesToSerialize = new HashSet<string> { "LastName" };
                string json2 = JObject.FromObject(person, serializer).ToString();
            }
        }
