        using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace FileDownloader
    {
        class Program
        {
            static void Main(string[] args)
            {
                List allUrls = GetUrls().Select(x=>x.Trim()).ToList();
    
                Parallel.ForEach(allUrls, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, url =>
                {
                    try
                    {
                        WebRequest request = WebRequest.Create(url);
                        WebResponse response = request.GetResponse();
                        string originalFileName = response.ResponseUri.AbsolutePath.Substring(response.ResponseUri.AbsolutePath.LastIndexOf("/") + 1);
                        Stream streamWithFileBody = response.GetResponseStream();
                        using (Stream output = File.OpenWrite(@"C:\Ebooks_New\" + originalFileName))
                        {
                            streamWithFileBody.CopyTo(output);
                        }
    
                        Console.WriteLine("Downloded : " + originalFileName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Unable to Download : " + ex.ToString());
                        
                    }
                });
    
                Console.WriteLine("Finished : ************************");
                Console.ReadKey();
            }
    
            public static List GetUrls()
            {
                return new List() // Put list of URLs here
                {
                    "http://ligman.me/1IW1oab  ",
        "http://ligman.me/1Uixtlq  ",
        "http://ligman.me/1R9Ubgt  ",
        "http://ligman.me/1H4VXHT  ",
        "http://ligman.me/1f8XUKy  ",
        "http://ligman.me/1HBEUPi  ",
        "http://ligman.me/1NDTZR4  ",
        "http://ligman.me/1Uiy2f9  ",
        "http://ligman.me/1epZ0QU  ",
        "http://ligman.me/1JIhgjA  ",
        "http://ligman.me/1CQX5uG  ",
       }
      }
     }
    }
