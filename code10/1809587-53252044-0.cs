    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Runtime.InteropServices;
    public Bitmap ProcessWindowScreenshot(string ProcessName, bool ClientAreaOnly, float Dpi)  {
        using (var process = Process.GetProcessesByName(ProcessName)
                                    .FirstOrDefault(p => p.MainWindowHandle != IntPtr.Zero))  {
            if (process == null) return null;
            return GetProcessWindowScreenshot(GetProcessWindowRect(process.Id, ClientAreaOnly), Dpi);
        }
    }
    public Bitmap ProcessWindowScreenshot(int ProcessId, bool ClientAreaOnly, float Dpi)  {
        return GetProcessWindowScreenshot(GetProcessWindowRect(ProcessId, ClientAreaOnly), Dpi);
    }
    private Bitmap GetProcessWindowScreenshot(Rectangle WindowArea, float Dpi)
    {
        using (Bitmap bitmap = new Bitmap(WindowArea.Width, WindowArea.Height, PixelFormat.Format32bppArgb))
        {
            if (Dpi < 96f) Dpi = 96f;
            bitmap.SetResolution(Dpi, Dpi);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.CopyFromScreen(WindowArea.Location, Point.Empty, WindowArea.Size, CopyPixelOperation.SourceCopy);
                return (Bitmap)bitmap.Clone();
            };
        };
    }
    private Rectangle GetProcessWindowRect(int ProcessId, bool IsClientArea)
    {
        IntPtr hWnd = Process.GetProcessById(ProcessId).MainWindowHandle;
        if (IsClientArea) {
            return GetWindowClientRectangle(hWnd);
        }
        else {
            return GetWindowRectangle(hWnd);
        }
    }
