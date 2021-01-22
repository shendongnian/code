        static Bitmap LoadImage()
        {
            return (Bitmap)Bitmap.FromFile( @"e:\Tests\d_bigImage.bmp" ); // here is large image 9222x9222 pixels and 95.96 dpi resolutions
        }
        static void TestBigImagePartDrawing()
        {
            using( var absentRectangleImage = LoadImage() )
            {
                using( var currentTile = new Bitmap( 256, 256 ) )
                {
                    currentTile.SetResolution(absentRectangleImage.HorizontalResolution, absentRectangleImage.VerticalResolution);
                    using( var currentTileGraphics = Graphics.FromImage( currentTile ) )
                    {
                        currentTileGraphics.Clear( Color.Black );
                        var absentRectangleArea = new Rectangle( 3, 8963, 256, 256 );
                        currentTileGraphics.DrawImage( absentRectangleImage, 0, 0, absentRectangleArea, GraphicsUnit.Pixel );
                    }
                    currentTile.Save(@"e:\Tests\Tile.bmp");
                }
            }
        }
