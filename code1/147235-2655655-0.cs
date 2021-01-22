using DHS;
using Utility;
using SocketServices;
class Window1
{
    
    public ClientAppServer AppServer = new ClientAppServer();
    public LoginToken Token;
    
    public Window1()
	{
	  InitializeComponent();
	}
    private void login()
    {
        
        LoginHandler handler = new LoginHandler();
        Token = handler.RequestLogin("admin", "admin", localPort = 12000, serverAddress = "127.0.0.1", serverLoginPort = 11000, clienttype = LoginToken.eClientType.Client_Admin, timeoutInSeconds = 20);
        
        if (Token.Authenticated) {
            AppServer = new ClientAppServer(Token, true);
            AppServer.ReceiveRequest += ReceiveMessage;
            AppServer.RetrieveCollection(typeof(Gateways));
            
        }
    }
    
    private void ReceiveMessage(RemoteRequest rr)
    {
        
        if ((rr.TransferObject) is Gateways) {
            MessageBox.Show("dd");
            
        }
    }
    
    private void Button1_Click(System.Object sender, System.Windows.RoutedEventArgs e)
    {
        login();
    }
}
