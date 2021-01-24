    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyButtonDesigner))]
    public class MyButton : Button
    {
        protected override Size DefaultSize
        {
            get { return new Size(100, 100); }
        }
        //Optional, just to enable Reset context menu item
        void ResetSize()
        {
            Size = DefaultSize;
        }
    }
    public class MyButtonDesigner : ControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            var s = properties["Size"];
            base.PreFilterProperties(properties);
            properties["Size"] = s;
        }
    }
