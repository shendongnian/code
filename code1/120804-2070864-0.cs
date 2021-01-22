    public class MessageHooks
    {
        public static event Action<int> OnHookCallback;
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int trueKeyPressed = Marshal.ReadInt32(lParam);
                if (OnHookCallBack != null)
                {
                    OnHookCallback(trueKeyPressed);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
Guess what? Now your HookCallBack method doesn't even need to know of the existence of forms. Instead, your forms register themselves to the event handler as such:
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageHooks.OnHookCallBack += MessageHooks_OnHookCallBack;
            this.FormClosed += (sender, e) => MessageHooks.OnHookCallBack -= MessageHooks_OnHookCallBack; // <--- ALWAYS UNHOOK ON FORM CLOSE
        }
        void MessageHooks_OnHookCallBack(int keyPressed)
        {
            // do something with the keypress
        }
    }
