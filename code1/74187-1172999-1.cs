    public abstract class SelfRef<T> where T : SelfRef<T>
    {
        private readonly Func<T> childFactory;
        
        public T Parent { get; set; }
    
        protected SelfRef(Func<T> childFactory)
        {
            this.childFactory = childFactory;
        }
        
        public T AddNew()
        {
           return childFactory();
        }
    }
    
    public sealed class Ref1 : SelfRef<Ref1>
    {
        public Ref1()
            : base(() => new Ref1 { Parent = this })
        {            
        }
    }
