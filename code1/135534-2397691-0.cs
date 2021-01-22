    public class AutoSizeButton : Button
    {
    
        public new Image Image
        {
            get { return base.Image; }
            set 
            {
                Image newImage = new Bitmap(Width, Height);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(value, 0, 0, Width, Height);
                }
                base.Image = newImage;
            }
        }
    }
