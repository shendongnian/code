void XYZControl_MouseDown(object sender, MouseEventArgs e)
{
    var senderControl = (Control) sender;
    ...
    Cursor.Position = senderControl.PointToScreen(new Point(e.X, e.Y));   // Workaround!
    if (DoDragDrop(senderControl, DragDropEffects.Move) == DragDropEffects.Move)
    {
    ...
    }
....
}
