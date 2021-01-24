	public class Info
	{
		public string prop1 {get;set;}
		public string prop2 {get;set;}
		public int prop3 {get;set;}
		// Modified from 
		//public Dictionary<string, List<int>> prop4 {get;set}
		public List<Dictionary<string, int>> prop4 {get;set;}
	}
	public class Response
	{
		// Modified from 
		//public class Dictionary<string, List<Info>> Item {get;set;}
		public Dictionary<string, Info> Items {get;set;}
	}
