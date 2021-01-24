    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace MetaFileDrawTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Pen[] p = new Pen[] { Pens.Black, Pens.Red, Pens.Green };
                // Draw to three MetaFiles in Parallel.
                Parallel.For(0, 3, i =>
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var mfG = System.Drawing.Graphics.FromHwndInternal(IntPtr.Zero))
                        {
                            using (Metafile mf = new Metafile(ms, mfG.GetHdc(), EmfType.EmfPlusOnly, "Chart"))
                            {
                                using (var g = System.Drawing.Graphics.FromImage(mf))
                                {
                                    // Draw a slightly different line each time to see a difference...
                                    g.DrawLine(p[i], 10 * i, 10, 100, 100);
                                }
    
                                // Save the Metafile to the disc. (You might keep it in memory as well)
                                mf.Save("D:\\test" + i + ".wmf");
                            }
                        }
                    }
                });
 
                // Draw the three metafiles to the form (just to see how they look like)
                for (int i = 0; i <= 2; i++)
                {
                    e.Graphics.TranslateTransform(100 * (i + 1), 0);
                    e.Graphics.DrawImageUnscaled(Image.FromFile("D:\\test" + i + ".wmf"), 0, 0);
                    e.Graphics.ResetTransform();
                }
                // Create a file metafile to draw all single images to (one by one)
                using (var ms2 = new MemoryStream())
                {
                    using (var mfG = System.Drawing.Graphics.FromHwndInternal(IntPtr.Zero))
                    {
                        using (Metafile mf = new Metafile(ms2, mfG.GetHdc(), EmfType.EmfPlusOnly, "Chart"))
                        {
                            using (var g = System.Drawing.Graphics.FromImage(mf))
                            {
                                g.DrawImageUnscaled(Image.FromFile("D:\\test0.wmf"), 0, 0);  
                                g.DrawImageUnscaled(Image.FromFile("D:\\test1.wmf"), 0, 0);
                                g.DrawImageUnscaled(Image.FromFile("D:\\test2.wmf"), 0, 0);
                            }
                            // Save the combined file to disc
                            mf.Save("D:\\complete.wmf");
                            // draw the combined file to the form.
                            e.Graphics.DrawImageUnscaled(mf, 0, 0);
                        }
                    }
                }
            }
        }
