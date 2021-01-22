        public class MyAttribute : Attribute
        {
        }
        [AttributeUsage(AttributeTargets.Field)]
        public class MyCityAttribute : MyAttribute
        {
        }
        [AttributeUsage(AttributeTargets.Field]
        public class MyNameAttribute: MyAttribute
        {
        }
        
        public class Person
        {
            [MyCity]
            public string city = "New York";
            [MyCity]
            public string workCity = "Chicago";
            [MyName]
            public string fullName = "John Doe";
            public Person()
            {
            }
            public void DoSomething()
            {
                Type t = typeof(Person);
                FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);
                foreach (var field in fields)
                {
                    MyAttribute[] attributes = field.GetCustomAttributes(typeof(MyAttribute));
                    if (attributes.Count > 0)
                    {
                        if (attributes[0] is MyCityAttribute)
                        {
                            //Dosomething for city
                            break;
                        }
                        if (attributes[0] is MyNameAttribute)
                        {
                            //Dosomething for names
                            break;
                        }
                    }
                }
            }
        }
