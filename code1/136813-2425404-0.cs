      [TestFixture]
      public class DesktopDrawingTests {
        private const int DCX_WINDOW = 0x00000001;
        private const int DCX_CACHE = 0x00000002;
        private const int DCX_LOCKWINDOWUPDATE = 0x00000400;
    
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
    
        [DllImport("user32.dll")]
        private static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgn, uint flags);
    
        [Test]
        public void TestDrawingOnDesktop() {
          IntPtr hdc = GetDCEx(GetDesktopWindow(),
                               IntPtr.Zero,
                               DCX_WINDOW | DCX_CACHE | DCX_LOCKWINDOWUPDATE);
    
          using (Graphics g = Graphics.FromHdc(hdc)) {
            g.FillEllipse(Brushes.Red, 0, 0, 400, 400);
          }
        }
      }
