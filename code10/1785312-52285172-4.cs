    class Program
    {
        static void Main(string[] args)
        {
            CreateListFromType(typeof(Foo));
            CreateListFromType(typeof(int));
        }
        static object CreateListFromType(Type t)
        {
            // Create an array of the required type
            Array values = Array.CreateInstance(t, 50);
            
            // and fill it with values of the required type
            for (int i = 0; i < 50; i++)
            {
                values.SetValue(CreateFooFromType(t), i);
            }
            // Create a list of the required type, passing the values to the constructor
            Type genericListType = typeof(List<>);
            Type concreteListType = genericListType.MakeGenericType(t);
            object list = Activator.CreateInstance(concreteListType, new object[] { values }); 
            // DO something with list which is now an List<t> filled with 50 ts
            return list;
        }
        // Create a value of the required type
        static object CreateFooFromType(Type t)
        {
            return Activator.CreateInstance(t);
        }
    }
    class Foo
    {
        public Foo() { }
    }
