    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public class ComboBoxEx : ComboBox {
        private string mCue;
        public string Cue {
            get { return mCue; }
            set {
                mCue = value;
                updateCue();
            }
        }
        private void updateCue() {
            if (this.IsHandleCreated)
                SendMessageCue(this.Handle, CB_SETCUEBANNER, IntPtr.Zero, mCue ?? "");
        }
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            updateCue();
        }
        // P/Invoke
        private const int CB_SETCUEBANNER = 0x1703;
        [DllImport("user32.dll", EntryPoint="SendMessageW", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessageCue(IntPtr hWnd, int msg, IntPtr wp, string lp);
    }
