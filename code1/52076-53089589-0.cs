    public class Anything
    {
        private int data, data2; //field
        public Anything()
        {
            data = default(int);
        }
        public int Data { get; set; }
    }
    public class GenericParentClass<T>
    {
        public static void StaticMethod(T data)
        {
            // do some job
        }
        public void InstanceMethod(T data)
        {
            // do some job
        }
    }
    public sealed class UsefulController<T> : GenericParentClass<T> where  T : Anything, new()
    {
        //all static public methods must be placed before all non-static public methods. [StyleCop Rule: SA1204]
        public static new void StaticMethod(T data)  //'UsefulController'.StaticMethod(Anything) hides inherited member 'GenericParentClass<Anything>.StaticMethod(Anything)'. Use the new keyword if hiding was intended.
        {
            GenericParentClass<T>.StaticMethod(data);  //'data' is a variable but used like a type //arugement type T is not assignable to parameter type 'data'.
        }
        public void EncapsulatedStaticMethod()
        {
            T @class = new T(); //cannot create an instance of the variable type T because it does not have the new() constraint. //T is type and @class is variable and new is an instance.
            StaticMethod(@class);  
        }
        public void EncapsulatedInstanceMethod(T data)
        {
            base.InstanceMethod(data);
        }
    }
    public class Container
    {
        public UsefulController<Anything>  B { get; set; }
    }
    public class Testing   
    {
        public static void Main()
        {
            Anything @var = new Anything();
            var c = new Container();
            c.B.InstanceMethod(null);   
            c.B.EncapsulatedStaticMethod();    
            c.B.EncapsulatedInstanceMethod(var);  
        }
    }
