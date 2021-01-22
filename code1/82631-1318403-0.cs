private void Form1_Load(object sender, EventArgs e)
{
    SetFeatureToAllControls(this.Controls);    
}
private void SetFeatureToAllControls(Control.ControlCollection cc)
{
    if (cc != null)
    {
        foreach (Control control in cc)
        {
            control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            SetFeatureToAllControls(control.Controls);
        }
    }
}
void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
{
    if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
    {
        e.IsInputKey = true;
    }
}
