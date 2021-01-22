    public interface IFoo<T> : IBar<T> {}
    public class Foo : IFoo<Foo> {}
    
    var implementedInterfaces = typeof( Foo ).GetType().GetInterfaces();
    foreach( var interfaceType in implementedInterfaces ) {
        if ( false == interfaceType.IsGeneric ) { continue; }
        var genericType = interfaceType.GetGenericTypeDefinition();
        if ( genericType == typeof( IFoo<> ) ) {
            // do something !
            break;
        }
    }
