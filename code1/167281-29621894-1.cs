protected override void OnClick(EventArgs e)
{
        base.OnClick(e);
        this.Parent.Focus();
        this.dropDown.Show(this);
}
