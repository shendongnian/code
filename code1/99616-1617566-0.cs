    public class Person
    {
        public string Name;
        public Person Friend;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "John";
            Person p2 = new Person();
            p2.Name = "Mike";
            p1.Friend = p2;
            Person[] group = new Person[] { p1, p2 };
            var serializer = new DataContractSerializer(group.GetType(), null, 
                0x7FFF /*maxItemsInObjectGraph*/, 
                false /*ignoreExtensionDataObject*/, 
                true /*preserveObjectReferences : this is where the magic happens */, 
                null /*dataContractSurrogate*/);
            serializer.WriteObject(Console.OpenStandardOutput(), group);
        }
    }
