    public partial class App : Application
    {
    
        static internal void ShowWin2(Win1 win1)
        {
            Win2 win2 = new Win2();
            // Copy Win1 stuff to Win2 here
            Application.Current.MainWindow = win2;
            win2.Show();
    
        }
    }
