    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WinFormsKeyHook
    {
        public partial class Form1 : Form
        {
            private static bool _caps;
            private static bool _num;
    
            public Form1()
            {
                InitializeComponent();
    
                KeyboardHook kh = new KeyboardHook();
                kh.KeysToObserve.AddRange(new List<Keys> { Keys.CapsLock, Keys.NumLock });
                kh.InstallHook();
                kh.KeyDown = key => ProcessKeyDown(key);
    
                _caps = Control.IsKeyLocked(Keys.CapsLock);
                _num = Control.IsKeyLocked(Keys.NumLock);
            }
    
            private void ProcessKeyDown(Keys key)
            {
    
                if (key == Keys.CapsLock)
                {
                    _caps = !_caps;
                }
                if (key == Keys.NumLock)
                {
                    _num = !_num;
                }
    
                this.ShowState(_num, _caps);
            }
    
            internal void ShowState(bool num, bool caps)
            {
                if (!num && !caps)
                {
                    this.Hide();
                    return;
                }
    
                this.label1.Text = "";
                this.label1.Text += num ? "NUM " : "";
                this.label1.Text += caps ? "CAPS" : "";
    
                if (!this.Visible)
                {
                    this.Show();
                }
            }
        }
    }
