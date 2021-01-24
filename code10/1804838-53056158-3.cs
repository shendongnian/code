    using System;
    using System.Windows.Forms;
    using System.Diagnostics; //PROCESS
    using System.Runtime.InteropServices; //DLL IMPORT
    using System.IO; //PATH
    
    namespace ShowApp
    {
        public partial class Main : Form
        {
            //FOR FINDING WINDOW
            [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
    
            //FOR FOCUSING WINDOW
            [DllImport("USER32.DLL")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);
    
            //FOR MAXIMIZING WINDOW
            private const int SW_MAXIMIZE = 3;
            [DllImport("USER32.DLL")]
            private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            public Main()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                bool bluestack = false;
    
                Process[] processlist = Process.GetProcessesByName("Bluestacks");//YOU SHOULD GET SPECIFIC PROC NAME TO MAKE IT EASIER AND LESSER PERMISSION ISSUE
    
                foreach (Process theprocess in processlist)
                {
                    bluestack = true; //SINCE WE SPECIFIED THE PROCESS, THIS WILL ONLY EXECUTE IF THE TARGET APP IS RUNNING
    
                    theprocess.WaitForInputIdle();
                    IntPtr extWindow = theprocess.MainWindowHandle;
    
                    //FOCUS WINDOW
                    SetForegroundWindow(extWindow);
    
                    //BONUS: USE THIS TO MAXIMIZE WINDOW
                    //ShowWindow(theprocess.MainWindowHandle, SW_MAXIMIZE);
                }
    
                this.Hide();
    
                if (!bluestack)
                {
                    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:/ProgramData/BlueStacks/Client/Bluestacks.exe");
                    Process.Start(new ProcessStartInfo(path));
                }
                else
                {
    
                }
            }
        }
    }
