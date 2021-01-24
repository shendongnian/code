    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyControlDesigner))]
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }
        void InitializeComponent() { }
        public Color SomeColorProperty { get; set; }
        public string[] Items { get; set; }
    }
    public class MyControlDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionList;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionList == null)
                    actionList = new DesignerActionListCollection(new[] {
                        new MyControlActionList(this) });
                return actionList;
            }
        }
    }
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
            get
            {
                return control.SomeColorProperty;
            }
            set
            {
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
            return new DesignerActionItemCollection()
            {
                new DesignerActionMethodItem(this, "EditItems", "Edit Items",  true),
                new DesignerActionPropertyItem("SomeColorProperty", "Some Color"),
            };
        }
    }
