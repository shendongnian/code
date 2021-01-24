    public class DataContainer
    {
        public string stringType { get; set; }
        public int intType { get; set; }
    	public bool boolType {get; set}
	
        public DataContainer(string string_type, int int__type, bool bool_type)
        {
           stringType = string_type;
           intType = int__type;
    	   boolType = bool_type;
        }
    }
