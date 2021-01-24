    protected void Submit_Click(object sender, EventArgs e)
        {
            Thread current = Thread.CurrentThread;
            WebDetails BTlibrary2 =BTlibrary;
            Thread t = new Thread(() => { BTlibrary2 = processes(BTlibrary2); }, 2500000);
            t.Start();
            t.Join();
            
            Session["BTLib"] = BTlibrary2;
           // Thread.Sleep(10000);
            
        }
    protected void Sendmail(object sender, EventArgs e)
        {
            List<DirectorDetail> Details = new List<DirectorDetail>();
            BTlibrary = (WebDetails) Session["BTLib"];
