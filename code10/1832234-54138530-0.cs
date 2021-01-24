    public abstract class BaseSerializerOptions
    {
        public Boolean SortComponents { get; set; }
    }
    public class TextSerializerOptions : BaseSerializerOptions
    {
        public Int32 TrimStrings { get; set; }
    }
    public class BinarySerializerOptions : BaseSerializerOptions
    {
        public Boolean SkipNulls { get; set; }
    }
    public abstract class BaseSerializer<T> where T : BaseSerializerOptions
    {
        public abstract void Serialize(Object obj, Stream s, T opt);
    }
    public class TextSerializer : BaseSerializer<TextSerializerOptions>
    {
        public override void Serialize(Object obj, Stream s, TextSerializerOptions opt)
        {
        }
    }
    public class BinarySerializer : BaseSerializer<BinarySerializerOptions>
    {
        public override void Serialize(Object obj, Stream s, BinarySerializerOptions opt)
        {
        }
    }
