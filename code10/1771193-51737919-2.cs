    void Main()
    {
        void TestRequest(string userAgent)
        {
            Stopwatch timer = new Stopwatch();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://youtube.com");
            request.UserAgent = userAgent;
    
            timer.Start();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Console.WriteLine(timer.Elapsed);
                timer.Stop();
            }
        }
        
        string mobileWin8UserAgent = @"Mozilla/5.0 (Mobile; Windows Phone 8.1; Android 4.0; ARM; Trident/7.0; Touch; rv:11.0; IEMobile/11.0; NOKIA; Lumia 520) like iPhone OS 7_0_3 Mac OS X AppleWebKit/537 (KHTML, like Gecko) Mobile Safari/537";
        string netscape3UserAgent = @"Mozilla/3.0 (Win95; I)";
        
        TestRequest(mobileWin8UserAgent);
        TestRequest(netscape3UserAgent);
    }
