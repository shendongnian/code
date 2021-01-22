Using the built in libraries for asp.net (System.Runtime.Serialization and System.ServiceModel.Web) you can get what you want pretty easily:
    string[][] parsed = null;
    var jsonStr = @"[[""Boston"",""142"",""JJK""],[""Miami"",""111"",""QLA""],[""Sacramento"",""042"",""PPT""]]";
    using (var ms = new System.IO.MemoryStream(System.Text.Encoding.Default.GetBytes(jsonStr)))
    {
    	var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(string[][]));
    	parsed = serializer.ReadObject(ms) as string[][];
    }
