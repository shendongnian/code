    class Program
    {
        static void Main()
        {
            var list = new ArrayList();
            list.Add("item1");
            list.Add("item2");
            // Serialize the list to a file
            var serializer = new BinaryFormatter();
            using (var stream = File.OpenWrite("test.dat"))
            {
                serializer.Serialize(stream, list);
            }
    
            // Deserialize the list from a file
            using (var stream = File.OpenRead("test.dat"))
            {
                list = (ArrayList)serializer.Deserialize(stream);
            }
        }
    }
