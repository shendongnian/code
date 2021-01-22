    class myControlDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            MyPanel myPanel = component as MyPanel;
            this.EnableDesignMode(myPanel.InnerPanel, "InnerPanel");
            this.EnableDesignMode(myPanel.InnerTableLayout, "InnerTableLayout");
        }
    }
