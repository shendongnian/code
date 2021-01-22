C#
// Serializes and deserializes System.Type
public class TypeSerializationSurrogate : ISerializationSurrogate {
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context) {
        info.AddValue(nameof(Type.FullName), (obj as Type).FullName);
    }
    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector) {
        return Type.GetType(info.GetString(nameof(Type.FullName)));
    }
}
// Just a stub, doesn't need an implementation
public class TypeStub : Type { ... }
// Binds "System.RuntimeType" to our TypeStub
public class TypeSerializationBinder : SerializationBinder {
    public override Type BindToType(string assemblyName, string typeName) {
        if(typeName == "System.RuntimeType") {
            return typeof(TypeStub);
        }
        return Type.GetType($"{typeName}, {assemblyName}");
    }
}
// Selected out TypeSerializationSurrogate when [de]serializing Type
public class TypeSurrogateSelector : ISurrogateSelector {
    public virtual void ChainSelector(ISurrogateSelector selector) => throw new NotSupportedException();
    public virtual ISurrogateSelector GetNextSelector() => throw new NotSupportedException();
    public virtual ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector selector) {
        if(typeof(Type).IsAssignableFrom(type)) {
            selector = this;
            return new TypeSerializationSurrogate();
        }
        selector = null;
        return null;
    }
}
Usage Example:
C#
var formatter = new BinaryFormatter() {
    SurrogateSelector = new TypeSurrogateSelector(),
    Binder = new TypeDeserializationBinder()
}
byte[] bytes
using (var stream = new MemoryStream()) {
    GetBinaryFormatter().Serialize(stream, typeof(string));
    bytes = stream.ToArray();
}
using (var stream = new MemoryStream(bytes)) {
    type = (Type)GetBinaryFormatter().Deserialize(stream);
    Assert.Equal(typeof(string), type);
}
