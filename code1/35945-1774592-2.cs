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
  
...
    public class ConfigurableQualityPictureBox : PictureBox
    {
        // Note: the use of the "?" indicates the value type is "nullable."  
        // If the property is unset, it doesn't have a value, and therefore isn't 
        // used when the OnPaint method executes.
        System.Drawing.Drawing2D.SmoothingMode? smoothingMode;
        System.Drawing.Drawing2D.CompositingQuality? compositingQuality;
        System.Drawing.Drawing2D.InterpolationMode? interpolationMode;
        public System.Drawing.Drawing2D.SmoothingMode? SmoothingMode
        {
            get { return smoothingMode; }
            set { smoothingMode = value; }
        }
        public System.Drawing.Drawing2D.CompositingQuality? CompositingQuality
        {
            get { return compositingQuality; }
            set { compositingQuality = value; }
        }
        public System.Drawing.Drawing2D.InterpolationMode? InterpolationMode
        {
            get { return interpolationMode; }
            set { interpolationMode = value; }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (smoothingMode.HasValue)
                pe.Graphics.SmoothingMode = smoothingMode.Value;
            if (compositingQuality.HasValue)
                pe.Graphics.CompositingQuality = compositingQuality.Value;
            if (interpolationMode.HasValue)
                pe.Graphics.InterpolationMode = interpolationMode.Value;
            // this line is needed for .net to draw the contents.
            base.OnPaint(pe);
        }
    }
