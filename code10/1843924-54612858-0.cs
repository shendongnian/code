private void Something(object sender, EventArgs e)
{
    btnSend_click(this, EventArgs.Empty);
}
Or
private void Something(object sender, EventArgs e)
{
    btnSend_click(sender, e);
}
