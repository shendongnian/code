    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    namespace MyControlProject
    {
        [Designer(typeof(MyControlDesigner))]
        public class MyControl : Control
        {
            protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
            {
                height = 50;
                base.SetBoundsCore(x, y, width, height, specified);
            }
        }
    
        internal class MyControlDesigner : ControlDesigner
        {
            MyControlDesigner()
            {
                base.AutoResizeHandles = true;
            }
            public override SelectionRules SelectionRules
            {
                get
                {
                    return SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable;
                }
            }
        }
    }
