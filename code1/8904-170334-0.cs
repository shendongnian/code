    public class ToolStripDropDownEx : ToolStripDropDownButton
    {
        public ToolStripDropDownEx(string text)
        {
        }
        protected override void OnMouseHover(EventArgs e)
        {
            if (this.Parent != null)
                Parent.Focus();
            base.OnMouseHover(e);
        } 
    }
