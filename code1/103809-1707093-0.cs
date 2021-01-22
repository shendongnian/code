    public partial class DocumentVersion : FileVersion
    {
    	public DocumentVersion() : base() { }
    
    	public DocumentVersion(FileVersion version) : this()
    	{
    		this.id = version.id;
    		// etc.
    	}
    
    	public string Link { get;set; }
    }
