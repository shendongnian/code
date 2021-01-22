    public class Download
    {
        string _filename;
    
        Download(string filename)
        {
           _filename = filename;
        }
    
        public void download(string filename)
        {
           //download code
        }
    }
    
    Download = new Download(filename);
    Thread thread = new Thread(new ThreadStart(Download.download);
