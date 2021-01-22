    public class TextboxX : TextBox
    {
        public event EventHandler DoingAPaint;
        protected override void WndProc(ref Message m)
        {
            switch ((int)m.Msg)
            {
                case (int)NativeMethods.WindowMessages.WM_PAINT:
                case (int)NativeMethods.WindowMessages.WM_ERASEBKGND:
                case (int)NativeMethods.WindowMessages.WM_NCPAINT:
                case 8465: //not sure what this is WM_COMMAND?
                    if(DoingAPaint!=null)DoingAPaint(this,EventArgs.Empty);
                    break;
            }           
            base.WndProc(ref m);
        }
    }
