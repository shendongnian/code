    public class MyUserControlDesigner : ControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.EnableDesignMode(((MyUserControl)this.Control).ContentsPanel,
                "ContentsPanel");
        }
    }
