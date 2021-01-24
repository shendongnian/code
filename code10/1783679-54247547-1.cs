    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Forms.Design;
    public class MyTableLayoutPanelActionList : DesignerActionList
    {
        MyTableLayoutPanel control;
        ControlDesigner designer;
        DesignerActionList actionList;
        public MyTableLayoutPanelActionList(ControlDesigner designer, 
            DesignerActionList actionList) : base(designer.Component)
        {
            this.designer = designer;
            this.actionList = actionList;
            control = (MyTableLayoutPanel)designer.Control;
        }
        public Color BackColor
        {
            get { return control.BackColor; }
            set
            {
                TypeDescriptor.GetProperties(Component)["BackColor"]
                    .SetValue(Component, value);
            }
        }
        private void DoSomething()
        {
            MessageBox.Show("My Custom Verb added!");
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            foreach (DesignerActionItem item in actionList.GetSortedActionItems())
                items.Add(item);
            var category = "New Actions";
            items.Add(new DesignerActionMethodItem(this, "DoSomething", 
                "Do something!", category, true));
            items.Add(new DesignerActionPropertyItem("BackColor", "Back Color",
                category));
            return items;
        }
    }
