    class Program
    {
        static int Main() {
            WebRequest wr = HttpWebRequest.Create("http://google.com/");
            HttpWebResponse wresp = (HttpWebResponse)wr.GetResponse();
    
            string outFile = @"c:\tmp\google.html";
    
            using (StreamReader sr = new StreamReader(wresp.GetResponseStream()))
            {
                 using(StreamWriter sw = new StreamWriter(outFile, false)) {
                      sw.Write(sr.ReadToEnd());
                 }
            }
    
            BrowseFile(outFile);
    
            return 0;
       }
    
       static void BrowseFile(string filePath)
       {
           ProcessStartInfo startInfo = new ProcessStartInfo();
           startInfo.FileName = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
           startInfo.Arguments = filePath;
           Process.Start(startInfo);
       }
    }
