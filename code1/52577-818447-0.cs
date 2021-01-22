using System.Windows.Forms;
public class MyDisplay : Panel
{
    public MyDisplay()
    {
        this.DoubleBuffered = true;
        // or
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        UpdateStyles();
    }
}
