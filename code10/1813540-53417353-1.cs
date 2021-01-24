    public interface ISettingValue
    {
        void Write();
    }
    
    public class StringSetting : ISettingValue
    {
    	readonly string _data;
    	public StringSetting(string data) => _data = data;
    	public void Write() 
    	{
    		//Call third-party code to write the string (value of _data).
    	}
    }
    public class IntSetting : ISettingValue
    {
    	readonly int _data;
    	public IntSetting(int data) => _data = data;
    	public void Write() 
    	{
    		//Call third-party code to write the integer (value of _data).
    	}
    }
    
    public class Setting
    {
        public string Section { get; set; }
        public string Key { get; set; }
        public ISettingValue Value { get; set; }
    
        public Setting(string section, string key, ISettingValue value)
        {
            Section = section;
            Key = key;
            Value = value;
        }
    
        public void Write()
        {
            Value.Write();
        }
    }
