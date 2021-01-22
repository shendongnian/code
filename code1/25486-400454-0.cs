    public class Service1 : System.Web.Services.WebService
    {
    
        [WebMethod]
        public void Log(int foo, int bar)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        }
    
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            throw new NotImplementedException();
        }
    }
