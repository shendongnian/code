        // ********************************************** ScaleBitmap
        
        /// <summary>
        /// Scale a bitmap by a scale factor, growing or shrinking 
        /// both axes, maintaining the aspect ratio
        /// </summary>
        /// <param name="inputBmp">
        /// Bitmap to scale
        /// </param>
        /// <param name="scale_factor">
        /// Factor by which to scale
        /// </param>
        /// <returns>
        /// New bitmap containing the original image, scaled by the 
        /// scale factor
        /// </returns>
        /// <citation>
        /// A Bitmap Manipulation Class With Support For Format 
        /// Conversion, Bitmap Retrieval from a URL, Overlays, etc.,
        /// Adam Nelson, The Code Project, September 2003.
        /// </citation>
        private Bitmap ScaleBitmap ( Bitmap  bitmap,
                                     float   scale_factor )
            {
            Graphics    g = null;
            Bitmap      new_bitmap = null;
            Rectangle   rectangle;
            int  height = ( int ) ( ( float ) bitmap.Size.Height *
                                    scale_factor );
            int  width = ( int ) ( ( float ) bitmap.Size.Width *
                                   scale_factor );
            new_bitmap = new Bitmap ( width,
                                      height,
                                      PixelFormat.Format24bppRgb );
                     
            g = Graphics.FromImage ( ( Image ) new_bitmap );
            g.InterpolationMode = InterpolationMode.High;
            g.ScaleTransform ( scale_factor, scale_factor );
            rectangle = new Rectangle ( 0,
                                        0,
                                        bitmap.Size.Width,
                                        bitmap.Size.Height );
            g.DrawImage ( bitmap,
                          rectangle,
                          rectangle,
                          GraphicsUnit.Pixel );
            g.Dispose ( );
            return ( new_bitmap );
            }
