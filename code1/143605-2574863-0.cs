    static class Program
    {
       static void Main(string[] args) 
       {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          new MyApp().Run(args);
       }
    
       public class MyApp : WindowsFormsApplicationBase
       {
          protected override void OnCreateSplashScreen()
          {
             this.SplashScreen = new MySplashScreen();
          }
    
          protected override void OnCreateMainForm() 
          {
             // Do stuff that requires time
             System.Threading.Thread.Sleep(5000);
             // Create the main form and the splash screen
             // will automatically close at the end of the method
             this.MainForm = new MyMainForm();
          }
       }  
    } 
