    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Hyper.ComponentModel;
    namespace Test {
        class Person {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        class Program {
            static void Main() {
                HyperTypeDescriptionProvider.Add(typeof(Person));
                var properties = new Dictionary<string, object> { { "Id", 10 }, { "Name", "Fred Flintstone" } };
                Person person = new Person();
                DynamicUpdate(person, properties);
                Console.WriteLine("Id: {0}; Name: {1}", person.Id, person.Name);
                Console.ReadKey();
            }
            public static void DynamicUpdate<T>(T entity, Dictionary<string, object>  {
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(typeof(T)))
                    if (properties.ContainsKey(propertyDescriptor.Name))
                        propertyDescriptor.SetValue(entity, properties[propertyDescriptor.Name]);
            }
        }
    }
