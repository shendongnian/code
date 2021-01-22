     internal sealed class Program
     { 
      /// <summary>
      /// Program entry point.
      /// </summary>
      [STAThread]
      public static void Main(string[] args)
      {
      	bool newMutex;
      	System.Threading.Mutex mutex = new System.Threading.Mutex(true, "{9F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}", out newMutex);
      	
         // Attempt aquire the mutex
         if(newMutex)
         {
          // If we are able to aquire the mutex, it means the application is not running.
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
    
             // Create the new tray icon
             MyTray myTray = new MyTray();
             
             Application.AddMessageFilter(myTray);
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
    
     public class MyTray : IMessageFilter
     {
      private NotifyIcon notifyIcon = new NotifyIcon();
      private Form myForm = new Form();
      
      public MyTray()
      {
      	 this.notifyIcon.Icon = System.Drawing.Icon.FromHandle(new System.Drawing.Bitmap(16,16).GetHicon());
         this.notifyIcon.Visible = true;
         this.notifyIcon.DoubleClick += delegate(object sender, EventArgs e) { ShowForm(); };
      }
      
      	 void ShowForm()
      	 {
    	  	this.notifyIcon.Visible = false;	  	  	
     	  	this.myForm.ShowDialog();	
     	  	this.notifyIcon.Visible = true;
    	  }
     	  
    	public bool PreFilterMessage(ref Message m)
    	{
    	   // If the message is the 'show me' message, then hide the icon and show the form.
    	   if(m.Msg == NativeMethods.WM_SHOWME)
    	   {
    		   	if (!this.myForm.Visible)
    		   	{
    				ShowForm();
    				return true; // Filter the message
    		   	}
    	   }
    	   
    	   return false; // Forward the message
    	}
     }
