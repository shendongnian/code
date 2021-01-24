    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    namespace ImageLoad
    {
      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          byte[] data = File.ReadAllBytes("test.jpg");
          this.pictureBox1.Image = GetImage(data);
        }
        private static Image GetImage(byte[] data)
        {
          using (MemoryStream ms = new MemoryStream(data))
          {
            return (Image.FromStream(ms));
          }
        }
      }
    }
