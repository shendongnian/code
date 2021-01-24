    private void btnSend_Click(object sender, EventArgs e)
    {
        Task.Run(() => LoadData(System.Threading.SynchronizationContext.Current, progressBar1));
    }
    private void LoadData (System.Threading.SynchronizationContext synchContext, ProgressBar1ObjectType progressBar)
    {
        string filePath = tbPath.Text;
        ETLBusiness etlBusiness = new ETLBusiness(filePath);
        synchContext.Post(state => etlBusiness.LoadData(progressBar), null);
    }
