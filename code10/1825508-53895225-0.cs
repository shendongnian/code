    using System;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	private static string JsonWithNull = @"{ 'height': '25', 'width': null }";
    	
    	public static void Main()
    	{
    		var settings = new JsonSerializerSettings()
    		{
    			NullValueHandling = NullValueHandling.Ignore
    		};
    		
    		Image image = JsonConvert.DeserializeObject<Image>(JsonWithNull, settings);
    		
    		Console.WriteLine("The image has a height of '{0}' and a width of '{1}'", image.height, image.width);
    	}
    }
    
    public class Image
    {	
        public int height { get; set; }
        public Uri url { get; set; }
        public int width { get; set; }
    }
