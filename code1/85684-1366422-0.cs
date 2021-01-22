    public partial class Form1 : Form {
        protected override CreateParams CreateParams {
            get {
                CreateParams par = base.CreateParams;
                par.Style = par.Style | 0x20000; // Turn on the WS_MINIMIZEBOX style flag
                return par;
            }
        }
    }
