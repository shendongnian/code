    using System;
	using System.Net;
	using Newtonsoft.Json;
	using System.Collections.Generic;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			//json url https://api.myjson.com/bins/1dbuse
			WebClient c = new WebClient();
			string json = c.DownloadString("https://api.myjson.com/bins/1dbuse");
			
			var ra = JsonConvert.DeserializeObject<List<Rootobject>>(json);
			Console.WriteLine(ra.First().qqq);
		}
	}
	
	public class Rootobject
	{
		public string qqq { get; set; }
		public string rrrr { get; set; }
		public Abc abc { get; set; }
		public Xyz xyz { get; set; }
		
	}
	public class Abc
	{
		public string abc1 { get; set; }
		public string abc2 { get; set; }
		public string abc3 { get; set; }
		public string abc4 { get; set; }
		public DateTime abc5 { get; set; }
	}
	public class Xyz
	{
		public string xyz1 { get; set; }
		public string xyz2 { get; set; }
		public string xyz3 { get; set; }
		public string xyz4 { get; set; }
		public DateTime xyz5 { get; set; }
	}
