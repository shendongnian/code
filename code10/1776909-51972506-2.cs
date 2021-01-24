    [ExecuteInEditMode]
    public class TitleChanger : MonoBehaviour
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        public static extern bool SetWindowText(System.IntPtr hwnd, System.String lpString);
    
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern System.IntPtr GetActiveWindow();
    
        void Start()
        {
            IntPtr windowPtr = GetActiveWindow();
            SetWindowText(windowPtr, Application.productName  + " [" + Application.unityVersion +"]");
        }
        void OnRenderObject()
        {
            IntPtr windowPtr = GetActiveWindow();
            SetWindowText(windowPtr, Application.productName + " [" + Application.unityVersion + "]");
        }
    }
