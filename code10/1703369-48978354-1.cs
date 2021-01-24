    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace KeyboardIndicators {
      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
    
          PictureBox pictureBox = new PictureBox();
    
          Image myBitmap = Image.FromFile("cube.png");
          Size bitmapSize = new Size(myBitmap.Width, myBitmap.Height);
    
          this.Size = bitmapSize;
          pictureBox.ClientSize = bitmapSize;
    
          pictureBox.Image = myBitmap;
          pictureBox.Dock = DockStyle.Fill;
          this.Controls.Add(pictureBox);
          this.FormBorderStyle = FormBorderStyle.None;
        }
    
        protected override CreateParams CreateParams {
          get {
            CreateParams createParams = base.CreateParams;
            createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
    
            return createParams;
          }
        }
      }
    }
