    using ProtoBuf;
    using ProtoBuf.Meta;
    
    [ProtoContract]
    public abstract class BaseOutput
    {
        public abstract string OutputName { get; }
        [ProtoMember(1)]
        public int X { get; set; }
    }
    
    [ProtoContract]
    public class MyOutput : BaseOutput
    {
        public override string OutputName { get { return "MyOutput"; } }
        [ProtoMember(11)]
        public double A { get; set; }
        [ProtoMember(12)]
        public double B { get; set; }
        [ProtoMember(13)]
        public double C { get; set; }
    
        public override string ToString()
            => $"A={A}, B={B}, C={C}"; // to show working
    }
    
    class Program
    {
        static void Main()
        {
            var pluginType = typeof(MyOutput); // after loading the plugin etc
            var baseType = RuntimeTypeModel.Default[typeof(BaseOutput)];
            baseType.AddSubType(42, pluginType);
    
            BaseOutput obj = new MyOutput { A = 1, B = 2, C = 3 };
            var clone = Serializer.DeepClone(obj);
    
            // outputs: A=1, B=2, C=3 - so: working (yay!)
            System.Console.WriteLine(clone.ToString());
        }
    }
