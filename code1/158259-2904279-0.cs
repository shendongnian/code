    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
    public class SpringLabel : ToolStripStatusLabel {
        public SpringLabel() {
            this.Spring = true;
        }
        protected override void OnPaint(PaintEventArgs e) {
            var flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            var bounds = new Rectangle(0, 0, this.Bounds.Width, this.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, bounds, this.ForeColor, flags);
        }
    }
