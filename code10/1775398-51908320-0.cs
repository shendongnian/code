    using System;
    using System.Collections.Generic;
    using System.Linq;
					
    public class Program
    {
	    public static void Main()
	    {
		    var examples = new List<string>
		    {
			    "https://www.example.com/exampleVideos/stuffs_videos/3323232/?result=33",
			    "https://www.example.com/exampleVideos/stuffs_videos/3323232/?result=33"
		    };
		
		    int idPositionInUrl = 5;
		
		    foreach (var url in examples)
  		    {
			    var id = url.Split('/')
				    .ElementAt(idPositionInUrl);
			
			    Console.WriteLine("Id: " + id);
		    }
	    }
    }
