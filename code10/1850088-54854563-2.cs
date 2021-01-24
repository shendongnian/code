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
