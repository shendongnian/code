    public class ThumbnailPictureBox
    {
      private PictureBox _pictureBox;
    
      public ThumbnailPictureBox(PictureBox pictureBox)
      {
        _pictureBox = pictureBox;
      }
    
      public bool Visible
      {
        get { return _pictureBox.Visible; }
        set { _pictureBox.Visible = value; }
      }
    
     // etc...
    }
