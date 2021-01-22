    namespace MyNamespace
    {
        public enum DataModelType { Company, Person }
        public class Company
        {
        }
        public class Person
        {
        }
        public class ObjectFactory
        {
            public static object CreateByEnum(DataModelType modelType)
            {
                string enumText = modelType.ToString(); // will return for example "Company"
                Type classType = Type.GetType("MyNamespace." + enumText); // the Type for Company class
                object t = Activator.CreateInstance(classType); // create an instance of Company class
                return t;
            }
        }
    }
