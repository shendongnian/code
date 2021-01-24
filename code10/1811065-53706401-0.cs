    private void button1_Click(object sender, EventArgs e)
            {
                if (cap != null) //Why... Are you sure? Not cap==null ???
                {
                    cap.Dispose();
                    cap = new VideoCapture(0);
                }
    
                
                Mat img = new Mat();
                cap.Grab();
                cap.Retrieve(img);
                if (pictureBox1.Image != null)
                {
                    var tempImage = pictureBox1.Image;
                    pictureBox1.Image = null;
                    tempImage.Dispose();
    
                }
                pictureBox1.Image =new Bitmap( img.Bitmap);
                img.Dispose();
            }
