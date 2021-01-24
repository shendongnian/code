    using System;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    public class MyTableLayoutPanel : TableLayoutPanel
    {
        private IDesignerHost designerHost;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (DesignMode && Site != null)
            {
                designerHost = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (designerHost != null)
                {
                    var designer = (ControlDesigner)designerHost.GetDesigner(this);
                    if (designer != null)
                    {
                        var actions = designer.ActionLists[0];
                        designer.ActionLists.Clear();
                        designer.ActionLists.Add(new MyTableLayoutPanelActionList(designer, actions));
                    }
                }
            }
        }
    }
