    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    ...
    public partial class Form1 : Form {
        private static PrivateFontCollection myFonts;
        private static IntPtr fontBuffer;
        public Form1() {
            InitializeComponent();
            if (myFonts == null) {
                myFonts = new PrivateFontCollection();
                byte[] font = Properties.Resources.test;
                fontBuffer = Marshal.AllocCoTaskMem(font.Length);
                Marshal.Copy(font, 0, fontBuffer, font.Length);
                myFonts.AddMemoryFont(fontBuffer, font.Length);
            }
        }
        protected override void OnPaint(PaintEventArgs e) {
            FontFamily fam = myFonts.Families[0];
            using (Font fnt = new Font(fam, 16)) {
                TextRenderer.DrawText(e.Graphics, "Private font", fnt, Point.Empty, Color.Black);
                //e.Graphics.DrawString("Private font", fnt, Brushes.Black, 0, 0);
            }
        }
    }
