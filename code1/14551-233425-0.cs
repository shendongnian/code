    public abstract class BasicClassA
    {
    }
    public class ClassA<T> : BasicClassA
    {
    }
    
    public class ClassB : ClassA<ClassB>
    {
    }
    
    public class ClassC : ClassB
    {
    }
    
    public static T Method<T>() where T : BasicClassA
    {
        return null;
    }
