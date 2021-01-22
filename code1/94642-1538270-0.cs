    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    
    namespace JsonParser
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string data = "[[\"9\",\"3\"],[\"8\",\"4\"],[\"7\",\"4\"],[\"6\",\"5\"],[\"5\",\"6\"],[\"4\",\"4\"],[\"3\",\"4\"]]";
    			var stream = new MemoryStream(new ASCIIEncoding().GetBytes(data));
    			var deserializer = new DataContractJsonSerializer(typeof(List<List<string>>));
    			var result = (List<List<string>>)deserializer.ReadObject(stream);
    		}
    	}
    }
