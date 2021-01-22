    public abstract class Base
    {
        public abstract void Use();
        public abstract object GetProp();
    }
    
    public abstract class GenericBase<T> : Base
    {
        public T Prop { get; set; }
        public override object GetProp()
        {
            return Prop;
        }
    }
    
    public class StrBase : GenericBase<string>
    {
        public override void Use()
        {
            Console.WriteLine("Using string: {0}", Prop);
        }
    }
    
    public class IntBase : GenericBase<int>
    {
        public override void Use()
        {
            Console.WriteLine("Using int: {0}", Prop);
        }
    }
