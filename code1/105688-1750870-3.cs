     internal sealed class Program
     {
      static System.Threading.Mutex mutex = new System.Threading.Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
      
      /// <summary>
      /// Program entry point.
      /// </summary>
      [STAThread]
      private static void Main(string[] args)
      {
       // Attempt aquire the mutex
             if(mutex.WaitOne(TimeSpan.Zero, true))
             {
              // If we are able to aquire the mutex, it means the application is not running.
                 Application.EnableVisualStyles();
                 Application.SetCompatibleTextRenderingDefault(false);
                 
                 // Create the new tray icon
                 MyTray myTray = new MyTray();
                 
                 Application.Run();
                 
                 // Release the mutex on exit
                 mutex.ReleaseMutex();
             }
             else
             {
                // If the aquire attempt fails, the application is already running
                // so we broadcast a windows message to tell it to wake up.
                 NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
             }
         }
     }
     
     internal class NativeMethods
     {
         public const int HWND_BROADCAST = 0xffff;
         public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
         
         [DllImport("user32")]
         public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
         
         [DllImport("user32")]     
         public static extern int RegisterWindowMessage(string message);
     }
     
     public class MyTray : Control
     {
      private NotifyIcon notifyIcon = new NotifyIcon();
      
      public MyTray()
      {
       this.notifyIcon.Visible = true;
      }
      
      /// <summary>
      /// This method listens to all windows messages either broadcast or sent to this control
      /// </summary>
      protected override void WndProc(ref Message m)
      {
       // If the message is the 'show me' message, then hide the icon and show the form.
       if(m.Msg == NativeMethods.WM_SHOWME)
       {
        this.notifyIcon.Visible = false;
        using (Form mainForm = new Form())
        {
         mainForm.ShowDialog();
         this.notifyIcon.Visible = true;
        }  
       }
       else
       {
        base.WndProc(ref m);    
       }   
      }
     }
