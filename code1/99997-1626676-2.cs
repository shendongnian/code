    [DataContract]
    public class Result
    {
        [DataMember(Name="d")]
        public string[][] d { get; set; }
    }
Then it's as simple as wrapping your result up like so: { "d": /*your results*/ }. See below for an example:
    Result parsed = null;
    var jsonStr = @"[[""Boston"",""142"",""JJK""],[""Miami"",""111"",""QLA""],[""Sacramento"",""042"",""PPT""]]";
    using (var ms = new MemoryStream(Encoding.Default.GetBytes(string.Format(@"{{ ""d"": {0} }}", jsonStr))))
    {
    	var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Result));
    	parsed = serializer.ReadObject(ms) as Result;
    }
