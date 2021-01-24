    Thread _myThread = null;
    private void btnSend_Click(object sender, EventArgs e)
    {
        SynchronizationContext synchContext = SynchronizationContext.Current;
        _myThread = new Thread(() => LoadData(synchContext, progressBar1));
        myThread.Start();
    }
    private void LoadData (System.Threading.SynchronizationContext synchContext, ProgressBar1ObjectType progressBar)
    {
        string filePath = tbPath.Text;
        ETLBusiness etlBusiness = new ETLBusiness(filePath);
        synchContext.Post(state => etlBusiness.LoadData(progressBar), null);
        _myThread.Abort();
    }
