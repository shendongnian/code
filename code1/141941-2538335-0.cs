    class OriginalImage: Form
    {
        private Image image;
        private PictureBox pb;
    
        public OriginalImage()
        {
            pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
    
            pb.Dock = DockStyle.Fill; // this will make the PictureBox occupy the
                                      // whole form
    
            Controls.Add(pb);
    
            image = Image.FromFile(@"Image/original.jpg");
    
            this.ClientSize = new Size(image.Width, image.Height); // this allows you to
                                                                   // size the form while
                                                                   // accounting for the
                                                                   // border
    
            this.Text = "Original image";
    
            pb.Image = image; // use this instead of drawing it yourself.
        }
    }
