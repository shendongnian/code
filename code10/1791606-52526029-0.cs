    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += async delegate
            {
                var g = Graphics.FromHwnd(IntPtr.Zero);
                var mouseNewRect = new Rectangle(Point.Empty, new Size(30, 30));
                var pen = new Pen(Brushes.Chocolate);
                while (true)
                {
                    mouseNewRect.Location = Cursor.Position;
                    g.DrawRectangle(pen, mouseNewRect);
                    await Task.Delay(500);
                    InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                }
            };
        }
        
        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
    }
