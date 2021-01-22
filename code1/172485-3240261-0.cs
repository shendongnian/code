    public void ThreadMethod()
    {
      pnlCapturePicture.Invoke((Action)(() =>
      {
        PictureBox pb = new PictureBox(); 
        pnlCapturePicture.Controls.Add(pb); 
        pb.Dock = DockStyle.Fill; 
        pb.ImageLocation = photopath; 
      }));
    }
