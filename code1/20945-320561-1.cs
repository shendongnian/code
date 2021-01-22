    private void Form1_Load(object sender, EventArgs e)     
           {
                byte[] data = File.ReadAllBytes("c:\\t.jpg");
        
                using (Stream originalBinaryDataStream = new MemoryStream(data))
                {
                    // This works perfectly fine, if use this method (which i can't).
                    //image = new Bitmap("Chick.jpg");
        
        
                    // This throws an exception when it's deserialized.
                    // It doesn't like the memory stream reference?
                    originalBinaryDataStream.Seek(0, SeekOrigin.End);
                    pictureBox1.Image=  new Bitmap(originalBinaryDataStream);
                }
            }
