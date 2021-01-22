    public void GetDimensionsFromImageTest()
            {
                Image Image = new Bitmap(10, 10);
                ImageHelpers_Accessor.ImageDimensions expected = new ImageHelpers_Accessor.ImageDimensions(10,10);
                
                ImageHelpers_Accessor.ImageDimensions actual;
                actual = ImageHelpers_Accessor.GetDimensionsFromImage(Image);
                /*USING IT HERE >>>*/
                Assert.AreEqual(GetObjectAsJson(expected), GetObjectAsJson(actual));
            }
