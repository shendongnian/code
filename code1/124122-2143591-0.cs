    class Program
    {
        static void Main(string[] args)
        {
            MyClass c = new MyClass() { Name = "Test", IsAlive = true };
            XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, c);
                Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
            }
            Console.ReadLine();
        }
    }
