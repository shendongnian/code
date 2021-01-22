        ...
        using System.Runtime.InteropServices;
        using System.Diagnostics;
        ...
    public class foo()
    {
        ...
        [DllImport ("user32")]
        internal static extern int GetWindowText (int hWnd, String text, int nMaxCount);
        [DllImport ("user32.dll")]
        public static extern int GetWindowTextLength (int hWnd);
        [DllImport ("user32.dll")]
        public static extern int FindWindow (String text, String class_name);
        [DllImport ("user32.dll")]
        public static extern int FindWindowEx (int parent, int start, String class_name);
        [DllImport ("user32.dll")]
        public static extern int GetWindow (int parent, uint cmd);
        public List<int> FindTitlelessWindows()
        {
            List<int> titleless = new List<int> ();
            Process [] procs = Process.GetProcesses ();
            IntPtr hWnd;
            foreach (Process proc in procs)
            {
                hWnd = proc.MainWindowHandle;
                if (hWnd != IntPtr.Zero)
                {
                    TraverseHierarchy (hWnd.ToInt32 (), 0, titleless);
                    
                }
            }
            foreach (int i in titleless)
            {
                System.Console.WriteLine (i);
            }
            return titleless;
        }
        public void TraverseHierarchy (int parent, int child, List<int> titleless)
        {
            String text = "";
            GetWindowText (parent, text, GetWindowTextLength (parent));
            if (String.IsNullOrEmpty (text))
            {
                titleless.Add (parent);
            }
            TraverseChildern (parent, titleless);
            TraversePeers (parent, child, titleless);
        }
        public void TraverseChildern(int handle, List<int> titleless)
        {
            // First traverse child windows
            const uint GW_CHILD = 0x05;
            int child = GetWindow (handle, GW_CHILD);
            if (0 != child)
            {
                TraverseHierarchy (child, 0, titleless);
            }
        }
        public void TraversePeers(int parent, int start, List<int> titleless)
        {
            // Next traverse peers
            int peer = FindWindowEx(parent, start, "");
            if (0 != peer)
            {
                TraverseHierarchy (parent, peer, titleless);
            }
            
        }
    }
