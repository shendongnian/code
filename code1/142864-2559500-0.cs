    abstract class A { }
    class B : A { }
    class C : B { }
    
    public static void Main(string[] args)
    {
        var target = typeof(C);
    
        var baseTypeNames = GetBaseTypes(target).Select(t => t.Name).ToArray();
    
        Console.WriteLine(String.Join(" : ", baseTypeNames));
    }
    
    private static IEnumerable<Type> GetBaseTypes(Type target)
    {
        do
        {
            yield return target.BaseType;
    
            target = target.BaseType;
        } while (target != typeof(object));
    }
