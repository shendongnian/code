public class DerivedPanel : Panel
{
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        Capture = true;
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        Capture = false;
        // Change your color or whatever here
    }
}
