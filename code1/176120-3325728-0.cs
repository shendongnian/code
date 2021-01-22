    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class FakeItPanel : Panel {
        private PictureBox mFakeIt;
    
        public new bool Enabled {
            get { return base.Enabled; }
            set {
                if (value) {
                    if (mFakeIt != null) mFakeIt.Dispose();
                    mFakeIt = null;
                }
                else {
                    mFakeIt = new PictureBox();
                    mFakeIt.Size = this.Size;
                    mFakeIt.Location = this.Location;
                    var bmp = new Bitmap(this.Width, this.Height);
                    this.DrawToBitmap(bmp, new Rectangle(Point.Empty, this.Size));
                    this.Parent.Controls.Add(mFakeIt);
                    this.Parent.Controls.SetChildIndex(mFakeIt, 0);
                }
                base.Enabled = value;
            }
        }
        protected override void Dispose(bool disposing) {
            if (disposing && mFakeIt != null) mFakeIt.Dispose();
            base.Dispose(disposing);
        }
    }
