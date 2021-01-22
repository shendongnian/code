      public partial class Form1 : Form, IMessageFilter {
        public Form1() {
          InitializeComponent();
          Application.AddMessageFilter(this);
          this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
        }
        private Keys mLastKey = Keys.None;
        public bool PreFilterMessage(ref Message m) {
          if (m.Msg == 0x100 || m.Msg == 0x104) {
            // Detect WM_KEYDOWN, WM_SYSKEYDOWN
            Keys key = (Keys)m.WParam.ToInt32();
            if (key != Keys.Control && key != Keys.Shift && key != Keys.Alt) {
              if (key == mLastKey) return true;
              mLastKey = key;
            }
          }
          else if (m.Msg == 0x101 || m.Msg == 0x105) {
            // Detect WM_UP, WM_SYSKEYUP
            Keys key = (Keys)m.WParam.ToInt32();
            if (key == mLastKey) mLastKey = Keys.None;
          }
          return false;
        }
      }
