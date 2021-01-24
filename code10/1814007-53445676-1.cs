    public class DerivedSchemaThatDoesNotNeedThisProperty : BaseSchema
    {
    ...
    	public override bool IsFilterRequired
    	{
    		get { return false; }
    		set { throw new NotImplementedException($"{nameof(IsFilterRequired)} property is not implemented in this class."); }
    	}
    ...	
    }
