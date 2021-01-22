    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    
    class MyButton : Button {
        private VisualStyleRenderer renderer;
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (this.Focused && Application.RenderWithVisualStyles && this.FlatStyle == FlatStyle.Standard) {
                if (renderer == null) {
                    VisualStyleElement elem = VisualStyleElement.Button.PushButton.Normal;
                    renderer = new VisualStyleRenderer(elem.ClassName, elem.Part, (int)PushButtonState.Normal);
                }
                Rectangle rc = renderer.GetBackgroundContentRectangle(e.Graphics, new Rectangle(0, 0, this.Width, this.Height));
                rc.Height--;
                rc.Width--;
                using (Pen p = new Pen(Brushes.DarkGray)) {
                    e.Graphics.DrawRectangle(p, rc);
                }
            }
        }
    }
