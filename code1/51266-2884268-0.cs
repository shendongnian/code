    public class TransparentPanel : Panel
    {
        Timer Wriggler = new Timer();
        public TransparentPanel()
        {
            Wriggler.Tick += new EventHandler(TickHandler);
            this.Wriggler.Interval = 500;
            this.Wriggler.Enabled = true;
        }
        protected void TickHandler(object sender, EventArgs e)
        {
            this.InvalidateEx();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT 
                return cp;
            }
        }
        protected void InvalidateEx()
        {
            if (Parent == null)
            {
                return;
            }
            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Do not allow the background to be painted  
        }
    }
