    public class HighQualitySmoothPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            // This is the only line needed for anti-aliasing to be turned on.
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // the next two lines of code (not comments) are needed to get the highest 
            // possible quiality of anti-aliasing. Remove them if you want the image to render faster.
            pe.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // this line is needed for .net to draw the contents.
            base.OnPaint(pe);
        }
    }
