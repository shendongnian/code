    public class Page1 : Page
    {
      public Page1 : base() {
        PreInit += Page_PreInit;
      }
      void Page_PreInit(object sender, EventArgs e)
      {
        Master.Init += Master_Init;
      }
      void Master_Init(object sender, EventArgs e)
      {
        //code
      }
    }
