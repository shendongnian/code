    public interface A
    {
    }
    public class B : A
    {
    }
    public class C : A
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<A> list = new List<A>(new A[] { new B(), new C() });
            var serializer = new DataContractSerializer(
                list.GetType(), new[] { typeof(B), typeof(C) });
            var sb = new StringBuilder();
            using (var stringWriter = new StringWriter(sb))
            using (var writer = XmlWriter.Create(stringWriter))
            {
                serializer.WriteObject(writer, list);
            }
            using (var stringReader = new StringReader(sb.ToString()))
            using (var reader = XmlReader.Create(stringReader))
            {
                list = (List<A>)serializer.ReadObject(reader);
            }
        }
    }
