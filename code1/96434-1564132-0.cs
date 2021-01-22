    public delegate DataReceivedEventHandler(object sender, DataEventArgs e);
    public event DataReceivedEventHandler DataReceived=new delegate{};
 
    public void OnDataReceived(object sender, DataEventArgs e)
    {
        DataReceived(sender, e);
    }
    
