private void Image_MouseMove(object sender, MouseEventArgs e)
{
    DeepZoomToolTip.IsOpen = true;
    DeepZoomToolTip.HorizontalOffset = e.GetPosition(LayoutRoot).X;
    DeepZoomToolTip.VerticalOffset = e.GetPosition(LayoutRoot).Y;
}
private void Image_MouseLeave(object sender, MouseEventArgs e)
{
    DeepZoomToolTip.IsOpen = false;
}
