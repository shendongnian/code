    [Guid("123565C4-C5FA-4512-A560-1D47F9FDFA20")]
    public interface IConfig
    {
    	[DispId(1)]
    	string Destination{ get; }
    
    	[DispId(2)]
    	void Unserialize();
    
    	[DispId(3)]
    	void Serialize();
    }
    
    [ComVisible(true)]
    [Guid("12AC8095-BD27-4de8-A30B-991940666927")]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class Config : IConfig
    {
    	public Config()
    	{
    	}
    
    	public string Destination
    	{
    		get { return ""; }
    	}
    
    	public void Serialize()
    	{
    	}
    
    	public void Unserialize()
    	{
    	}
    }
