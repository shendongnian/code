    using System;
    using System.Net;
    using Newtonsoft.Json.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		 WebClient web = new WebClient();
    		 using (WebClient wc = new WebClient())
    		 {
    			var json = wc.DownloadString("https://unison.mtgradio.se/api/v2/timeline?channel_id=6&client_id=6690709&to=2018-10-02T08%3A00%3A50&from=2018-10-02T07%3A00%3A50&limit=40");
    			dynamic stuff = JArray.Parse(json);
    			string name = stuff[1].song.title;
    			Console.WriteLine(name);
    		 }
    	}
    }
