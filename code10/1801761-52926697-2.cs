    public Form1()
    {
        InitializeComponent();
        menuStrip1.Renderer = new BackgroundImageRenderer(); //menuStrip1 is the container for the toolstrip menu items.
    }
    private class BackgroundImageRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {                
            if (e.Item.Name == "toolStripMenuItem1")
            {                    
                Image backgroundImage = global::WindowsFormsApp1.Properties.Resources.Normal;
                if (e.Item.Selected)
                    backgroundImage = global::WindowsFormsApp1.Properties.Resources.Hover;
                e.Graphics.DrawImage(backgroundImage, 0, 0, e.Item.Width, e.Item.Height);
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
    } 
