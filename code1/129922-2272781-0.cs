    class Program
    {
        static void Main(string[] args)
        {
            string whatIsMyIp = "http://www.whatismyip.com/automation/n09230945.asp";
            WebClient wc = new WebClient();
            UTF8Encoding utf8 = new UTF8Encoding();
            string requestHtml = "";
            try
            {
                requestHtml = utf8.GetString(wc.DownloadData(whatIsMyIp));
            }
            catch (WebException we)
            {
                // do something with exception 
                Console.Write(we.ToString());
            }
            
            IPAddress externalIp = null;
            externalIp = IPAddress.Parse(requestHtml);
            Console.Write("IP Numaram:" + externalIp.ToString());
            Console.ReadKey(); 
        }
    }
