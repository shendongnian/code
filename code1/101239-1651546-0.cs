    public class SimpleHost : MarshalByRefObject
    {
        public void ProcessRequest(string page, string query, TextWriter writer)
        {
            SimpleWorkerRequest swr = new SimpleWorkerRequest(page, query, writer);
            HttpRuntime.ProcessRequest(swr);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Check to see if a given argument has been passed on the command-line
            SimpleHost host = (SimpleHost)ApplicationHost.CreateApplicationHost(
                typeof(SimpleHost), "/", Directory.GetCurrentDirectory());
    
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:9999/");
            listener.Start();
            Console.WriteLine("Listening for requests on http://localhost:9999/");
    
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                string page = context.Request.Url.LocalPath.Replace("/", "");
                string query = context.Request.Url.Query.Replace("?", "");
                using (var writer = new StreamWriter(context.Response.OutputStream))
                {
                    host.ProcessRequest(page, query, writer);
                }
                context.Response.Close();
            }
    
        }
    }
