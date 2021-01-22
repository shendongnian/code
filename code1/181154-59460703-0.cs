private Point diffPoint;
bool mouseDown = false;
private void Form1_MouseDown(object sender, MouseEventArgs e)
{
  //saves position difference
  diffPoint.X = System.Windows.Forms.Cursor.Position.X - this.Left;
  diffPoint.Y = System.Windows.Forms.Cursor.Position.Y - this.Top;
  mouseDown = true;
}
private void Form1_MouseUp(object sender, MouseEventArgs e)
{
  mouseDown = false;
}
private void Form1_MouseMove(object sender, MouseEventArgs e)
{
  if (mouseDown)
  {
    this.Left = System.Windows.Forms.Cursor.Position.X - diffPoint.X;
    this.Top = System.Windows.Forms.Cursor.Position.Y - diffPoint.Y;
  }
}
This works, tested.
