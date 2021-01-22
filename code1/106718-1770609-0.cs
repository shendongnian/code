    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    namespace Color_tool
    {
    public partial class Form1 : Form
    {
        Regex rgbInputR;
        Regex rgbInputG;
        Regex rgbInputB;
        Match R, G, B;
        int r;
        int g;
        int b;
        string colorX;
        [DllImport("gdi32")]
        private static extern int GetPixel(IntPtr hdc, int x, int y);
        [DllImport("User32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        private static readonly IntPtr DesktopDC = GetWindowDC(IntPtr.Zero);
        public static System.Drawing.Color GetPixelAtCursor()
        {
            System.Drawing.Point p = Cursor.Position;
            return System.Drawing.Color.FromArgb(GetPixel(DesktopDC, p.X, p.Y));
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            colorX = GetPixelAtCursor().ToString();
            Color backX = GetPixelAtCursor();
            this.BackColor = Color.FromArgb(r,g,b);
            label1.Text = colorX;
            RGB_value();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
                timer1.Enabled = true;
            else
                timer1.Enabled = false;
        }
        private void RGB_value()
        {
            rgbInputR = new Regex(@"(?<=R=)\d{0,3}");
            rgbInputG = new Regex(@"(?<=G=)\d{0,3}");
            rgbInputB = new Regex(@"(?<=B=)\d{0,3}");
            Match R, G, B;
            R = rgbInputR.Match(colorX);
            G = rgbInputG.Match(colorX);
            B = rgbInputB.Match(colorX);
            //had to flip the R and B ???
            b = int.Parse(R.Groups[0].Value);
            g = int.Parse(G.Groups[0].Value);
            r = int.Parse(B.Groups[0].Value);
        }
     }
    }
