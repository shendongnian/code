      public class MsgWindow : Microsoft.WindowsCE.Forms.MessageWindow {
    
        public const int WM_SER = 0x500;
        public const int WM_SER_SCANDONE = WM_SER + 0;
    
        frmMain msgform { get; set; }
    
        public MsgWindow(frmMain msgform) {
          this.msgform = msgform;
        }
    
        protected override void WndProc(ref Microsoft.WindowsCE.Forms.Message m) {
          switch (m.Msg) {
            case WM_SER_SCANDONE:
              this.msgform.RespondToMessage(WM_SER_SCANDONE);
              break;
            default:
              break;
          }
          base.WndProc(ref m);
        }
    
      }
    
      public partial class frmMain : Form {
        
        public frmMain() {
          InitializeComponent();
        }
    
        public void RespondToMessage(int nMsg) {
          try {
            switch (nMsg) {
              case MsgWindow.WM_SER_SCANDONE:
                // do something here based on the message
                break;
              default:
                break;
            }
          } catch (Exception ex) {
            MessageBox.Show(string.Format("{0} - {1}", ex.Message, ex.ToString()), "RespondToMessage() Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            // throw;
          }
        }
    
      }
