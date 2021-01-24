        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        using Newtonsoft.Json.Serialization;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        public class Person {
            public int Id;
            public string FirstName;
            public string LastName;
        }
        public class SelectedPropertiesContractResolver<T> : CamelCasePropertyNamesContractResolver {
            HashSet<string> _selectedProperties;
            public SelectedPropertiesContractResolver(IEnumerable<string> selectedProperties) {
                _selectedProperties = selectedProperties.ToHashSet();
            }
            public override JsonContract ResolveContract(Type type) {
                return CreateContract(type);
            }
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
                if (type == typeof(T)) {
                    return base.CreateProperties(type, memberSerialization)
                        .Where(p => _selectedProperties.Contains(p.PropertyName, StringComparer.OrdinalIgnoreCase)).ToList();
                }
                return base.CreateProperties(type, memberSerialization);
            }
        }
        class Program {
            static void Main(string[] args) {
                var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
                var serializer = new JsonSerializer {
                    ContractResolver = new SelectedPropertiesContractResolver<Person>(new HashSet<string> { "Id", "FirstName" })
                };
                string json1 = JObject.FromObject(person, serializer).ToString();
                serializer = new JsonSerializer {
                    ContractResolver = new SelectedPropertiesContractResolver<Person>(new HashSet<string> { "LastName" })
                };
                string json2 = JObject.FromObject(person, serializer).ToString();
                Console.WriteLine(json1);
                Console.WriteLine(json2);
            }
        } 
