    public class SampleClass<TSerializable> {
        static SampleClass() {
            if(!Attribute.IsDefined(typeof(TSerializable),
                    typeof(SerializableAttribute))) {
                throw new InvalidOperationException("Not [Serializable]:" +
                    typeof(TSerializable).Name);
            }
        }
    }
    [Serializable] class Foo { }
    class Bar { }
    static class Program {
        static void Main() {
            new SampleClass<Foo>(); // ok
            new SampleClass<Bar>(); // fail
        }
    }
