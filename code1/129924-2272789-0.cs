    static void Main(string[] args)
        {
            const string url = "http://www.whatismyip.com/automation/n09230945.asp";
            var client = new WebClient();
            try
            {
                var myIp = client.DownloadString(url);
                Console.WriteLine("Your IP: " + myIp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error contacting website: " + ex.Message);
            }
        }
