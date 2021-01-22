    public interface ISerializerBase<T> { }
    public class SerializerBase<T> : ISerializerBase<T> { } 
    public class DirectChild : SerializerBase<DirectChild> { }
    public class InheritedChild : DirectChild, ISerializerBase<InheritedChild> { } 
    public class panelGenericIOGrid<T> where T: ISerializerBase<T>, new() { } 
     
