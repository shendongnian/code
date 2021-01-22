    void Main()
    {
    	CtorChaining ctorNoparam = new CtorChaining();
    	ctorNoparam.Dump();
    	//Result --> BaseDir C:\Program Files (x86)\Default\ 
    	
    	CtorChaining ctorOneparam = new CtorChaining("c:\\customDir");
    	ctorOneparam.Dump();	
    	//Result --> BaseDir c:\customDir 
    }
    public class CtorChaining
    {
    	public string BaseDir;
    	public static string DefaultDir = @"C:\Program Files (x86)\Default\";
    	
    	
    	public CtorChaining(): this(DefaultDir) {}
    	
    	public CtorChaining(string baseDir): this(baseDir, DefaultDir){}
    	
    	public CtorChaining(string baseDir, string defaultDir)
    	{
            //if baseDir == null, this.BaseDir = @"C:\Program Files (x86)\Default\"
            this.BaseDir = baseDir ?? defaultDir;
    	}
    }
