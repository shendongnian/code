    public abstract class Product
    {
        public int BaseParam { get; set; }
    
        public abstract ICommonInterface Visit(IProductVisitor productVisitor);
    }
    
    public class SpecificProductA : Product
    {
        public int ParamA {get;set;}
    
        public override ICommonInterface Visit(IProductVisitor productVisitor)
        {
            /* Forwards the SpecificProductA to the Visitor */
            return productVisitor.GetCommonInterface(this);
        }
    }
    
    public class SpecificProductB : Product
    {
        public int ParamB {get;set;}
    
        public override ICommonInterface Visit(IProductVisitor productVisitor)
        {
            /* Forwards the SpecificProductB to the Visitor */
            return productVisitor.GetCommonInterface(this);
        }
    }
