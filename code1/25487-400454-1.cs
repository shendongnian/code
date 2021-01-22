    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public void Log(int foo, int bar)
        {
            Thread a = new Thread(new ThreadStart(delegate()
            {
                // Do some processing here
                // For example, let it sleep for 10 secs
                Thread.Sleep(10000);
            }));
            a.Start();
        }
    }
