    public class ToolStripRender : ToolStripProfessionalRenderer
    {
        public ToolStripRender() : base() { }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.GetType() != typeof(ToolStrip))
                base.OnRenderToolStripBorder(e);
        }
    }
