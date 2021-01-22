    public class MyUserControlActionList : DesignerActionList
    {
        public MyUserControlActionList(MyUserControlDesigner designer) : base(designer.Component) { }
    
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();
            items.Add(new DesignerActionPropertyItem("DockInParent", "Dock in parent"));
            return items;
        }
    
        public bool DockInParent
        {
            get
            {
                return ((MyUserControl)base.Component).Dock == DockStyle.Fill;
            }
            set
            {
                TypeDescriptor.GetProperties(base.Component)["Dock"].SetValue(base.Component, value ? DockStyle.Fill : DockStyle.None);
            }
        }    
    }
