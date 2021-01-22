public static void HideBorders(Form form)
{
    Rectangle newRegion = form.Bounds;
    Rectangle formArea = form.Bounds;
    Rectangle clientArea = form.RectangleToScreen(form.ClientRectangle);
    formArea.Offset(form.Location);
    newRegion.Offset(clientArea.X - formArea.X, 0);
    newRegion.Width = clientArea.Width;
    newRegion.Height = (clientArea.Y - formArea.Y) + clientArea.Height;
    
    form.Region = new Region(newRegion);
}
