    public class Translation
    {
    	public int Id { get; set; }
    	public int Model { get; set; }
    	public int ModelId { get; set; }
    }
    
    public class BaseModel
    {
    	public BaseModel(int modelType)
    	{
    		ModelType = modelType;
    	}
    	public int Id { get; set; }
    	public int ModelType { get; set; }
    
    	public ICollection<Translation> Translations { get; set; }// only for internal use
    	public IEnumerable<Translation> ModelTypeTranslations
    	{
    		get
    		{
    			return this.Translations.Where(t => t.Model == this.ModelType);
    		}
    	}
    
    }
    
    public class SomeModel : BaseModel
    {
    	public SomeModel() : base(1) { }
    	public int SomeProperty { get; set; }
    }
    
    public class AnotherModel : BaseModel
    {
    	public AnotherModel() : base(2) { }
    	public int AnotherProperty { get; set; }
    }
