    public class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
             MainWindow window=new MainWindow();
             LogInViewModel vm=new LogInViewModel(); // You need to set DataContext...
             window.DataContext=vm; // ...before showing up the window.
             window.Show();
        }
     }
