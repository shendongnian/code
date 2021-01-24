    public partial class DDEServer_MainForm : Form
    {
      DdeServer server;
    
      /* snipped out code */
    
      public void runDDEServer()
      {
        try
        {
          server = new theDDEServer("dde_server", this);
          server.Register();
        }
        catch (Exception ex)
        {
          //--> you should definitely do something here. Print a message at least!
        }
      }
    
      /* snipped out code */
    
      //--> In the form designer, hook this method to the OnClosing event!
      private void closeForm(object sender, System.ComponentModel.CancelEventArgs e)
      {
          server.Unregister();
          server.Dispose();
      }
    }
