    public class Form1 : System.Windows.Forms.Form
    {
        static private SHDocVw.ShellWindows shellWindows = new
        SHDocVw.ShellWindowsClass();
    
        public Form1()
        {
           InitializeComponent();    
           foreach(SHDocVw.InternetExplorer ie in shellWindows)
           {
               MessageBox.Show("ie.Location:" + ie.LocationURL);
               ie.BeforeNavigate2 += new
               SHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.ie_BeforeNavigate2);
           }
    }
    
     public void ie_BeforeNavigate2(object pDisp , ref object url, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
     {
      MessageBox.Show("event received!");
     } 
    }
 
 
