    public class PixelBox : PictureBox
    {
        protected override void OnPaint (PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            // Either the docs on this are wrong, or it behaves differently in NearestNeighbor.
            // putting it to Half makes it NOT shift the whole thing up and to the left by half a (zoomed) pixel.
            pe.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            base.OnPaint(pe);
        }
    }
