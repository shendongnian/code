using System;
using System.Drawing;
using System.Windows.Forms;
class C:Form
{
static void Main(){Application.Run(new C());}
private Point? _MousePosition = null;
protected override void OnMouseMove(MouseEventArgs e) {
 _MousePosition = e.Location;
 this.Invalidate();
}
protected override void OnPaint(PaintEventArgs e) {
 if(_MousePosition.HasValue) {
  using(Pen skyBluePen = new Pen(Brushes.DeepSkyBlue)) {
   e.Graphics.DrawEllipse(skyBluePen, _MousePosition.Value.X - 150, _MousePosition.Value.Y - 150, 300, 300);
  }
 }
}
}
