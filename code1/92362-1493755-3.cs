DrawToBitmap only draws what's on-screen. If you want to draw the entire contents of the list you must iterate through the list to find the size of the contents then draw each item. Something like:
var f = yourControl.Font;
var lineHeight = f.GetHeight();
// Find size of canvas
var s = new SizeF();
using (var g = yourControl.CreateGraphics())
{
    foreach (var item in yourListBox.Items)
    {
        s.Height += lineHeight ;
        var itemWidth = g.MeasureString(item.Text, f).Width;
        if (s.Width &lt; itemWidth)
            s.Width = itemWidth;
    }
    if (s.Width &lt; yourControl.Width)
         s.Width = yourControl.Width;
}
using( var canvas = new Bitmap(s) )
using( var g = Graphics.FromImage(canvas) )
{
    var pt = new PointF();
    foreach (var item in yourListBox.Items)
    {
        pt.Y += lineHeight ;
        g.DrawString(item.Text, f, Brushes.Black, pt);
    }
    canvas.Save(wherever);
}
