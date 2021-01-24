    [DllImport("ole32.dll")]
    static extern int CoRegisterMessageFilter(IMessageFilter lpMessageFilter, out IMessageFilter lplpMessageFilter);
        
    private IMessageFilter oldMessageFilter;
    internal void InvokeAsyncCallToExcel()
    {
        Thread t = new Thread(this.RegisterFilter);
        t.SetApartmentState(ApartmentState.STA);
        t.Start();
    }
        
    private void RegisterFilter()
    {
        CoRegisterMessageFilter(this, out oldMessageFilter);
        Thread.Sleep(3000);
        CallExcel();
    }
        
    private void CallExcel()
    {
        try
        {
            this.Application.ActiveCell.Value2 = DateTime.Now.ToShortTimeString();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }
