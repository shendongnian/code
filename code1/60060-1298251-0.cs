    public class OverlayingControl : UserControl
    {
        /// <summary>
        /// Overrides the c# standard Paint Background to allow the custom background to be drawn 
        /// within the OnPaint function
        /// </summary>
        /// 
        /// <param name="e">Arguements used within this function</param>
        protected override void OnPaintBackground( PaintEventArgs e )
        {
            //Do Nothing 
        }
        protected override void OnPaint( PaintEventArgs e )
        {
            // Render the Parents image to a Bitmap. NB: bitmap dimensions and Parent Bounds can be changed to achieve the desitred effect
            Bitmap background = new Bitmap( Width, Height, PixelFormat.Format64bppArgb );
            Parent.DrawToBitmap( background, Parent.Bounds );
            // Paint background image             
            g.DrawImage( background, 0, 0, new RectangleF( Location, Size ), GraphicsUnit.Pixel );
            
            // Perform any alpha-blending here by drawing any desired overlay e.g.
            // g.FillRectangle( new SolidBrush( semiTransparentColor ), Bounds);
        }
        
    }
