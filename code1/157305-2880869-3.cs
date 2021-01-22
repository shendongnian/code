    namespace ConsoleApplication1
    {
        internal class Person
        {
            public Person(string name)
            {
                Name = name;
            }
    
            public string Name { get; set; }
        }
    }
    public static void Main()
            {
    
                Type type = typeof(Person);
    
                Type[] argTypes = new Type[] { typeof(String) };
    
                ConstructorInfo cInfo = type.GetConstructor(argTypes);
    
                object[] argVals = new object[] { "Some string" };
                Person p = (Person)cInfo.Invoke(argVals);
            }
