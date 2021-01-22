using System.Runtime.InteropServices;
//insert by Zswang(wjhu111#21cn.com) at 2007-05-22
[DllImport("gdi32.dll")]
public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
[DllImport("gdi32.dll")]
public static extern IntPtr CreateSolidBrush(int crColor);
[DllImport("gdi32.dll")]
public static extern bool ExtFloodFill(IntPtr hdc, int nXStart, int nYStart, 
    int crColor, uint fuFillType);
[DllImport("gdi32.dll")]
public static extern bool DeleteObject(IntPtr hObject);
[DllImport("gdi32.dll")]
public static extern int GetPixel(IntPtr hdc, int x, int y);
public static uint FLOODFILLBORDER = 0;
public static uint FLOODFILLSURFACE = 1;
private void button1_Click(object sender, EventArgs e)
{
    Graphics vGraphics = Graphics.FromHwnd(Handle);
    vGraphics.DrawRectangle(Pens.Blue, new Rectangle(0, 0, 300, 300));
    vGraphics.DrawRectangle(Pens.Blue, new Rectangle(50, 70, 300, 300));
    IntPtr vDC = vGraphics.GetHdc();
    IntPtr vBrush = CreateSolidBrush(ColorTranslator.ToWin32(Color.Red));
    IntPtr vPreviouseBrush = SelectObject(vDC, vBrush);
    ExtFloodFill(vDC, 10, 10, GetPixel(vDC, 10, 10), FLOODFILLSURFACE);
    SelectObject(vDC, vPreviouseBrush);
    DeleteObject(vBrush);
    vGraphics.ReleaseHdc(vDC);
}
Instead of using `Graphics vGraphics = Graphics.FromHwnd(Handle);` , if you are calling this in OnPaint event handler, you may use `e.Graphics` . Worked for me quite well. 
Sometimes its better not to reinvent algorithm and use existing routines, although you may get some problems with this when porting to Mono.
