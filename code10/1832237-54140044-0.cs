    public abstract class BaseSerializerOptions
    {
        Boolean SortComponents { get; set; }
    }
    public class TextSerializerOptions : BaseSerializerOptions
    {
        public Boolean TrimStrings { get; set; }
    }
    public class BinarySerializerOptions : BaseSerializerOptions
    {
        public Boolean SkipNulls { get; set; }
    }
    public class SerializerResult
    {
    }
    public static class Serializer
    {
        public static SerializerResult Write(Object obj, Stream s, BaseSerializerOptions opt)
        {
            switch (opt)
            {
                case TextSerializerOptions o: return WriteText(obj, s, o);
                case BinarySerializerOptions o: return WriteBinary(obj, s, o);
            }
            throw new Exception();
        }
        public static SerializerResult WriteText(Object obj, Stream s, TextSerializerOptions opt)
        {
            return null;
        }
        public static SerializerResult WriteBinary(Object obj, Stream s, BinarySerializerOptions opt)
        {
            return null;
        }
    }
    class Program
    {
        static void Test(BaseSerializerOptions o)
        {
            var obj = new Object();
            using (var fs = File.Open("...", FileMode.Create))
            {
                var r1 = Serializer.Write(obj, fs, o);
                CheckSerializerResults(r1);
            }
        }
        static void TestSerializers()
        {
            Test(new TextSerializerOptions { TrimStrings = true });
            Test(new BinarySerializerOptions { SkipNulls = false });
        }
        static void CheckSerializerResults(SerializerResult r)
        {
        }
    }
