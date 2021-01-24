    internal interface IMetadata
    {
      string CreateMetadata();
    }
    
    internal class Metadata : IMetadata
    {
      private readonly string location;
      public Metadata(string location)
      {
        this.location = location;
      }
      public string CreateMetadata()
      {
        return string.Empty;
      }
    }
    
    public interface IBaseType
    {
      void Perform();
    }
    
    public abstract class BaseType : IBaseType
    {
      private readonly IMetadata _metadata;
      private protected BaseType(IMetadata metadata) //No error
      {
    
      }
    
      internal BaseType(IMetadata metadata, int thing) //No error
      {
    
      }
    
      public abstract void Perform();
    }
    
    class Type1 : BaseType
    {
      public Type1(IMetadata metadata) :
      base(metadata)
      {
      }
    
      public Type1(IMetadata metadata, int thing) : base(metadata, thing)
      {
    
      }
    
      public override void Perform()
      {
        throw new NotImplementedException();
      }
    }
