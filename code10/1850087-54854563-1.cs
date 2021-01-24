public class MainForm : Form
{
    Form child1;
    Form child2;
    public MainForm()
    {
        Text = "MainForm";
        child1 = new ChildForm { Text = "Child1", ParentPtr = Handle };
        child2 = new ChildForm { Text = "Child2", ParentPtr = Handle };
        child1.Show(this);
        child2.Show(this);
    }
}
public class ChildForm : Form
{
    [DllImport("user32.dll")]
    public static extern bool SetFocus(IntPtr hWnd);
    private const int WM_KILLFOCUS = 0x0008;
    public IntPtr ParentPtr { get; set; }
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_KILLFOCUS) SetFocus(ParentPtr);
        base.WndProc(ref m);
    }
}
*Old answer:*
As @Jimi said, you are setting the owner which is causing this behavior.
This should work for you.
class MainForm : Form
{
    Form child1;
    Form child2;
    public MainForm()
    {
        Text = "MainForm";
        child1 = new Form { Text = "Child1" };
        child2 = new Form { Text = "Child2" };
        child1.Show();
        child2.Show();
    }
}
