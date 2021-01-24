    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        //Set the custom renderer for menu, to always show underlines
        ToolStripManager.Renderer = new MyRenderer();
        //Send two alt keys. The second one is to remove the focus from menu
        SendKeys.Send("%");
        SendKeys.Send("%");
    }
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextFormat &= ~TextFormatFlags.NoPrefix;
            e.TextFormat &= ~TextFormatFlags.HidePrefix;
            base.OnRenderItemText(e);
        }
    }
