    using System;
    using System.Net;
    using System.IO;
    using System.Text;
    
    					
    public class Program
    {
    	public static void Main()
    	{
    		
          ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    		
          HttpWebRequest request   = (HttpWebRequest)WebRequest.Create("https://ipapi.co/8.8.8.8/country/");
          HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
    	  var reader = new System.IO.StreamReader(response.GetResponseStream(), ASCIIEncoding.ASCII);
    	  Console.WriteLine(reader.ReadToEnd());
    
    	}
    }
