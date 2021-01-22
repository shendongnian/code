    class Program
    {
        [Serializable]
        public class Foo
        {
            public Func<string> Del;
        }
        static void Main(string[] args)
        {
            Foo foo = new Foo();
            foo.Del = Test;
            BinaryFormatter formatter = new BinaryFormatter();
            using (var stream = new FileStream("test.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, foo);
            }
            using (var stream = new FileStream("test.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                foo = (Foo)formatter.Deserialize(stream);
                Console.WriteLine(foo.Del());
            }
        }
        public static string Test()
        {
            return "test";
        }
    }
