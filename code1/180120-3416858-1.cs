    public interface ICommon
    {
        int Owner { get; }
        string Version();
    }
    public interface IA : ICommon
    public interface IB : ICommon
    private void CreateInstanceForProvider(ICommon c) 
    { 
        if (c == null) 
        { 
            ShowProviderNotInstanciatedMessage(); 
            return; 
        } 
     
        c.Owner = Handle.ToInt32(); 
        lbl_Text.Text = c.Version(); 
    } 
