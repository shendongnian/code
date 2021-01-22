    class Program
    {
       [Serializable]
       public class Foo
       {
           public Func<string> Del;
       }
       static void Main(string[] args)
       {
           Func<string> a = (() => "a");
           Func<string> b = (() => "b");
           Foo foo = new Foo();
           foo.Del = a;
           WriteFoo(foo);
           Foo bar = ReadFoo();
           Console.WriteLine(bar.Del());
           Console.ReadKey();
       }
       public static void WriteFoo(Foo foo)
       {
           BinaryFormatter formatter = new BinaryFormatter();
           using (var stream = new FileStream("test.bin", FileMode.Create, FileAccess.Write, FileShare.None))
           {
               formatter.Serialize(stream, foo);
           }
       }
       public static Foo ReadFoo()
       {
           Foo foo;
           BinaryFormatter formatter = new BinaryFormatter();
           using (var stream = new FileStream("test.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
           {
               foo = (Foo)formatter.Deserialize(stream);
           }
           return foo;
       }
    }
