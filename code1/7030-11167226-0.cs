    //IServiceWrapper is public class which is 
    //the same assembly with the internal class 
    var asm = typeof(IServiceWrapper).Assembly;
    //Namespace.ServiceWrapper is internal
    var type = asm.GetType("Namespace.ServiceWrapper");
    return (IServiceWrapper<T>)Activator
        .CreateInstance(type, new object[1] { /*constructor parameter*/ });
