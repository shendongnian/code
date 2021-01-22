    public Window1()
    {
       this.InitializeComponent();
       starthost();  
    }
    
    private void starthost()
    {
       host = new ServiceHost(typeof (GanadorService), 
                               new Uri[]{ new Uri("net.tcp://localhost:8000") });
    
       host.AddServiceEndpoint(typeof(IGanador), new NetTcpBinding(), "Contador");
       host.open(); //it fails with this line here but not in a button 
    }
    
    
    public class GanadorService : IGanador
    {
       .... (whatever methods you need) .....
    }
