    public class ClassA<T, PropType> : IDisposable 
                where T : DbContext, new()
                where PropType : TypesBaseClassOrSharedContract{
        private readonly T context = new T();
            
        private ClassB<PropType> _type;
        
        public ClassB<PropType> TypeProp
        {
            get
            {
                return _type ?? (_type= new ClassB<PropType>(context);
            }
        }    
           
    } 
