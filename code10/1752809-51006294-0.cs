	public interface IValidationEntity
	{
	    void Run(CtxTest context, IValidationEntity entity);
		string Details { get; }
	}	
