    public class Class1 { }
    public class BaseGeneric<T> : IBaseGeneric<T> { }
    public class BaseGeneric2<T> : IBaseGeneric<T>, IInterfaceBidon { }
    public interface IBaseGeneric<T> { }
    public class ChildGeneric : BaseGeneric<Class1> { }
    public interface IChildGeneric : IBaseGeneric<Class1> { }
    public class ChildGeneric2<Class1> : BaseGeneric<Class1> { }
    public interface IChildGeneric2<Class1> : IBaseGeneric<Class1> { }
    
    public class WrongBaseGeneric<T> { }
    public interface IWrongBaseGeneric<T> { }
    
    public interface IInterfaceBidon { }
    
    public class ClassA { }
    public class ClassB { }
    public class ClassC { }
    public class ClassB2 : ClassB { }
    public class BaseGenericA<T, U> : IBaseGenericA<T, U> { }
    public class BaseGenericB<T, U, V> { }
    public interface IBaseGenericB<ClassA, ClassB, ClassC> { }
    public class BaseGenericA2<T, U> : IBaseGenericA<T, U>, IInterfaceBidonA { }
    public interface IBaseGenericA<T, U> { }
    public class ChildGenericA : BaseGenericA<ClassA, ClassB> { }
    public interface IChildGenericA : IBaseGenericA<ClassA, ClassB> { }
    public class ChildGenericA2<ClassA, ClassB> : BaseGenericA<ClassA, ClassB> { }
    public class ChildGenericA3<ClassA, ClassB> : BaseGenericB<ClassA, ClassB, ClassC> { }
    public class ChildGenericA4<ClassA, ClassB> : IBaseGenericB<ClassA, ClassB, ClassC> { }
    public interface IChildGenericA2<ClassA, ClassB> : IBaseGenericA<ClassA, ClassB> { }
    
    public class WrongBaseGenericA<T, U> { }
    public interface IWrongBaseGenericA<T, U> { }
    
    public interface IInterfaceBidonA { }
