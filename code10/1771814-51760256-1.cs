    public class DataReader : IDataReader
    {
        IDeserializer _deserializer;
    	
        public DataReader(IDeserializer deserializer)
        {
    	    _deserializer = deserializer;
        }
    	
        public async Task<object> ReadJsonByKey(string jsonPath, string jsonKey)
        {
    	    var json =  File.ReadAllText(jsonPath);
    		
    		return _deserializer.Deserialize(json, jsonKey);
        }
    }
