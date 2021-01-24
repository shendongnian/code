	public class RootObject
	{
		public ResponseHeader responseHeader { get; set; }
		public Response response { get; set; }
		public Dictionary<string, Highlighting> highlighting { get; set; }
	} 
	public class Highlighting
	{   
		public List<string> _text_ { get; set; }
	}
