    namespace MyApplication
    {
        public class AppController
        {
             static AppController _AppController;
           
             public LoginWIndow LoginWIndow;
             //Constructor
             public void AppController()
             {
                 //Do what you will here, Start login form, bind events, w.e :)
                 if(true) //Your check
                 {
                     ShowLoginWindow();
                 }
             }
             public void ShowLoginWindow()
             {
                 LoginWIndow = new LoginWIndow();
                 LoginWIndow.ClosedForm += new FormClosedEventHander(ExitApplication);
                 LoginWIndow.Show();
             }
             public void ExitApplication(Object Sender, FormClosedEventArgs Args) 
             {
                //Some shutdown login Logic, then
                Application.Exit();
             }
    
             static AppController Instance
             {
                get
                {
                     if(_AppController == null)
                     {
                         _AppController = new AppController();
                     }
                     return _AppController;
                }
             }
        }
    }
