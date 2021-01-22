    void DrawImage()
            {
                //load both images
                Image mainImage = Bitmap.FromFile("PathOfImageGoesHere");
                Image imposeImage = Bitmap.FromFile("PathOfImageGoesHere");
    
                //create graphics from main image
                using (Graphics g = Graphics.FromImage(mainImage))
                {
                    //draw other image on top of main Image
                    g.DrawImage(imposeImage, new Point(0, 0));
    
                    //save new image
                    mainImage.Save("OutputFileName");
                }
                
            
            }
