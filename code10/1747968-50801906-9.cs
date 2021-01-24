    public class MyControlActionList : DesignerActionList
    {
        ControlDesigner designer;
        MyControl control;
        public MyControlActionList(ControlDesigner designer) : base(designer.Component)
        {
            this.designer = designer;
            control = (MyControl)designer.Control;
        }
        public Color SomeColorProperty
        {
            get { return control.SomeColorProperty;  }
            set {
                TypeDescriptor.GetProperties(
                    (object)this.Component)["SomeColorProperty"]
                    .SetValue((object)this.Component, (object)value);
            }
        }
        public void EditItems()
        {
            var editorServiceContext = typeof(ControlDesigner).Assembly.GetTypes()
                .Where(x => x.Name == "EditorServiceContext").FirstOrDefault();
            var editValue = editorServiceContext.GetMethod("EditValue",
                System.Reflection.BindingFlags.Static |
                System.Reflection.BindingFlags.Public);
            editValue.Invoke(null, new object[] { designer, this.Component, "Items" });
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            return new DesignerActionItemCollection() {
                new DesignerActionMethodItem(this, "EditItems", "Edit Items",  true),
                new DesignerActionPropertyItem("SomeColorProperty", "Some Color"),
            };
        }
    }
