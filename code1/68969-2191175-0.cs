    public class UserControlComboBox : ComboBox, IMessageFilter
    {
        public readonly MyControlClass UserControl = new MyControlClass();
        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == 0x0201) || (m.Msg == 0x0203))
            {
                if (DroppedDown)
                    HideUserControl();
                else
                    ShowUserControl();
           }
            else
            {
                base.WndProc(ref m);
            }
        }
        public bool PreFilterMessage(ref Message m)
        {
            // intercept mouse events
            if ((m.Msg >= 0x0200) && (m.Msg <= 0x020A))
            {
                if (this.UserControl.RectangleToScreen(this.UserControl.DisplayRectangle).Contains(Cursor.Position))
                {
                    // clicks inside the user control, handle normally
                    return false;
                }
                else
                {
                    // clicks outside the user controlcollapse it.
                    if ((m.Msg == 0x0201) || (m.Msg == 0x0203))
                        this.HideUserControl();
                    return true;
                }
            }
            else return false;
        }
        public new bool DroppedDown 
        {
            get { return this.UserControl.Visible; } 
        }
        protected void ShowUserControl()
        {
            if (!this.Visible)
                return;
            this.UserControl.Anchor = this.Anchor;
            this.UserControl.BackColor = this.BackColor;
            this.UserControl.Font = this.Font;
            this.UserControl.ForeColor = this.ForeColor;
            // you can be cleverer than this if you need to
            this.UserControl.Top = this.Bottom;
            this.UserControl.Left = this.Left;
            this.UserControl.Width = Math.Max(this.UserControl.Width, this.Width);
            this.Parent.Controls.Add(this.UserControl);
            this.UserControl.Visible = true;
            this.UserControl.BringToFront();
            base.OnDropDown(EventArgs.Empty);
            // start listening for clicks
            Application.AddMessageFilter(this);
        }
        protected void HideUserControl()
        {
            Application.RemoveMessageFilter(this);
            base.OnDropDownClosed(EventArgs.Empty);
            this.UserControl.Visible = false;
            this.Parent.Controls.Remove(this.UserControl);
            // you probably want to replace this with something more sensible
            this.Text = this.UserControl.Text;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.UserControl.Dispose();
            }
            base.Dispose(disposing);
        }
    }
