    /// <summary>
    /// A transparent control.
    /// </summary>
    public class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
        }
 
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return createParams;
            }
        }
 
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do not paint background.
        }
    }
