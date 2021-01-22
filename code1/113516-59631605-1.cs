    public class ToolStripRender : ToolStripProfessionalRenderer
    {
        public ToolStripRender() : base() { }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (!(e.ToolStrip is ToolStrip))
                base.OnRenderToolStripBorder(e);
        }
    }
