    using System.Collections.Generic;
    using System.Windows;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    class Vertex
    {
    	[JsonExtensionData]
    	public IDictionary<string, JToken> _additionalData;
    }
    
    var content = File.ReadAllText(@"file.json");
    var d = JsonConvert.DeserializeObject<Vertex>(content);
