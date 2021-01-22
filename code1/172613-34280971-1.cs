    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace DetectKeyChord
    {
        public partial class Form1 : Form
        {
            private const int WM_KEYDOWN = 0x100;
            private const int KEY_PRESSED = 0x80;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            public void ShortcutAction()
            {
                MessageBox.Show("Ctrl+Alt+K+P has been pressed.");
            }
    
            private bool IsKeyDown(Keys key)
            {
                return (NativeMethods.GetKeyState(key) & KEY_PRESSED) == KEY_PRESSED;
            }
    
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_KEYDOWN)
                {
                    //If any of the keys in the chord have been pressed, check to see if
                    //the entire chord is down.
                    if (new[] { Keys.P, Keys.K, Keys.ControlKey, Keys.Menu }.Contains((Keys)m.WParam))
                    {
                        if (IsKeyDown(Keys.ControlKey) && IsKeyDown(Keys.Menu) && IsKeyDown(Keys.K) && IsKeyDown(Keys.P))
                        {
                            this.ShortcutAction();
                        }
                    }
                }
                base.WndProc(ref m);
            }
        }
    
        public static class NativeMethods
        {
            [DllImport("USER32.dll")]
            public static extern short GetKeyState(Keys nVirtKey);
        }
    }
