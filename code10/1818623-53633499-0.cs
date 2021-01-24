    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    					
    namespace ConsoleApp1
    {
    	class Program
    	{
    		static void  Main(string[] args)
            {
                 string data = "<p>this is new document<img alt='' height='150' src='https://kuba2storage.blob.core.windows.net/kuba-appid-1/manual-1203/images/desert-20180824203530071.jpg' width='200'/>This is new document</p>";
                 var newdt = FetchImgsFromSource(data);
            
            }
        }
        public static List<string> FetchImgsFromSource(string htmlSource)
        {
            List<string> listOfImgdata = new List<string>();
            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
            var matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match m in matchesImgSrc)
            {
                string href = m.Groups[1].Value;
                listOfImgdata.Add(href);
            }
            return listOfImgdata;
        }
    }
