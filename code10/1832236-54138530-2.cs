    public class TextSerializer : BaseSerializer
    {
        public void Serialize(Object obj, Stream s, TextSerializerOptions opt)
        {
            this.Serialize(obj, s, opt);
        }
        public override void Serialize(object obj, Stream s, BaseSerializerOptions opt)
        {
            if (opt is TextSerializerOptions options)
            {
            }
            else
            {
            }
        }
    }
    public class BinarySerializer : BaseSerializer
    {
        public void Serialize(Object obj, Stream s, BinarySerializerOptions opt)
        {
            this.Serialize(obj, s, opt);
        }
        public override void Serialize(object obj, Stream s, BaseSerializerOptions opt)
        {
            if (opt is BinarySerializerOptions options)
            {
            }
            else
            {
            }
        }
    }
