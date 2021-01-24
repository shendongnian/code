    public class CustomJsonWriter : JsonTextWriter
    {
        public CustomJsonWriter(TextWriter writer): base(writer){}
    
        public override void WritePropertyName(string name)
        {
            base.WritePropertyName(name.Replace("zs:",string.Empty));
        }
    }
