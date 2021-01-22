    private void button10_Click(object sender, RoutedEventArgs e)
        {
            string url = @"http://eu.wowarmory.com/guild-info.xml?r=Eonar&n=Gifted and Talented"; 
            WebClient wc = new WebClient();
            // HOW DO I ADD A USER AGENT STRING (RESPONSE MAY VARY (I.E. HTML VS XML) IF PAGE THINKS CALL IS NOT CAPABABLE OF SUPPORTING XML TRANSFORMATIONS) 
            //wc.ResponseHeaders["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            
            wc.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            wc.DownloadStringAsync(new Uri(url));    
        }
        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string result = e.Result;
                XDocument ArmouryXML = XDocument.Parse(result);
                ShowGuildies(ArmouryXML);
            }
            else
            {
                MessageBox.Show("Something is complaining about security but not sure what!");
            }
        } 
