    private void btnSend_Click(object sender, EventArgs e)
    {
        Task.Run(() => LoadData(System.Threading.SynchronizationContext.Current));
    }
    private void LoadData (System.Threading.SynchronizationContext synchContext)
    {
        string filePath = tbPath.Text;
        ETLBusiness etlBusiness = new ETLBusiness(filePath);
        synchContext.Post(state => etlBusiness.LoadData(progressBar1), null);
    }
