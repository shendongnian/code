    public class FluentConvention : IPropertyConvention, IReferenceConvention  
    {      
        public void Apply(IPropertyInstance instance)
        {          
            instance.Not.Nullable();      
        }
    
        public void Apply(IManyToOneInstance instance)
        {
            instance.Not.Nullable();
        }
    }      
