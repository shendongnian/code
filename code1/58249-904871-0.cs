    using System;
    using System.Drawing;
    using System.Drawing.Text;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace RemoteFontTest
    {
        public partial class Form1 : Form
        {
            readonly PrivateFontCollection pfc = new PrivateFontCollection();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                WebRequest request = WebRequest.Create(@"http://somedomain.com/foo/blah/somefont.ttf");
                request.Credentials = CredentialCache.DefaultCredentials;
    
                WebResponse response = request.GetResponse();
    
                using (Stream fontStream = response.GetResponseStream())
                {
                    if (null == fontStream)
                    {
                        return;
                    }
    
                    int fontStreamLength = (int)fontStream.Length;
    
                    IntPtr data = Marshal.AllocCoTaskMem(fontStreamLength);
    
                    byte[] fontData = new byte[fontStreamLength];
                    fontStream.Read(fontData, 0, fontStreamLength);
    
                    Marshal.Copy(fontData, 0, data, fontStreamLength);
    
                    pfc.AddMemoryFont(data, fontStreamLength);
    
                    Marshal.FreeCoTaskMem(data);
                }
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    using (Font font = new Font(pfc.Families[0], 32, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        e.Graphics.DrawString(font.Name, font, brush, 10, 10, StringFormat.GenericTypographic);
                    }
                }
            }
        }
    }
