c#
protected override void OnClosing(CancelEventArgs e)
{
    this.Visibility = Visibility.Hidden;
    e.Cancel = true;
}
