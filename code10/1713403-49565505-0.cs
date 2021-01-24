    public interface IProductVisitor
    {
          ICommonInterface Visit(SpecificProductA productA);
    
          ICommonInterface Visit(SpecificProductB productB);
    }
    
    /* The purpose of this abstract class is to minimize the impact of the changes if I had to support another SpecificProductC. */ 
    public abstract class ProductVisitor : IProductVisitor
    {
          public virtual ICommonInterface GetCommonInterface(SpecificProductA productA)
          {
              throw new NotImplementedException();
          }
    
          public virtual ICommonInterface GetCommonInterface(SpecificProductB productB)
          {
              throw new NotImplementedException();
          }
    }
    
    public sealed class SpecificProductAVisitor : ProductVisitor
    {
          public override ICommonInterface GetCommonInterface(SpecificProductA productA)
          {
              /* This guy will deal with ParamA of SpecificProductA */
              return new ImplACommonInterface(productA);
          }
    }
    
    public sealed class SpecificProductBVisitor : ProductVisitor
    {
          public override ICommonInterface GetCommonInterface(SpecificProductB productB)
          {
              /* This guy will deal with ParamB of SpecificProductB */
              return new ImplBCommonInterface(productB);
          }
    }
