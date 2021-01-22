    public class ConfigManager
    {
	
       public virtual int MyPropOne { get; private set; }
	   public virtual string MyPropTwo { get; private set; }
	   public ConfigManager()
	   {
		Setup();
	   }
	   private void Setup()
	   {
		MyPropOne = 1;
		MyPropTwo = "test";
	   }
}
