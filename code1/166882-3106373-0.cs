    public class HostingClass : MarshalByRefObject
    {
        public void ProcessPage(string url)
        {
            using (StreamWriter sw = new StreamWriter("C:\temp.html"))
            {
                SimpleWorkerRequest worker = new SimpleWorkerRequest(url, null, sw);
                HttpRuntime.ProcessRequest(worker);
            }
                        // Ta-dah!  C:\temp.html has some html for you.
        }
    }
