    private void btnSend_Click(object sender, EventArgs e)
    {
        string filePath = tbPath.Text;
        ETLBusiness etlBusiness = new ETLBusiness(filePath);
        SynchronizationContext synchContext = SynchronizationContext.Current;
        Thread myThread = new Thread(() => synchContext.Post(state => etlBusiness.LoadData(progressBar), null));
        myThread.Start();
    }
