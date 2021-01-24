    public class A { };
    
    public class DtoA { };
    
    var source = ServiceClass.Get<A>();
    var dto = Mapper.Map<A, ADto>(source);
