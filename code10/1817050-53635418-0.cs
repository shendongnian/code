    //save the current Transformation state of the graphics object.
    var transState = e.Graphics.Save();
    
    // Setting keepAspectRatio to false will scale your image to full screen.
    // setting it to true will fill either the width or the height. you might need to use TranslateTransform method to move the image to the center.
    bool keepAspectRatio = false;
    // Calculate width and height ratios
    // if you currently render everything to 640px/480px, you can take those dimensions instead of the Image size I used to calculate the ratios.
    float widthRatio = this.DisplayRectangle.Width / MatheMage.Properties.Resources.ChooseMenu.Width;
    float heightRatio = this.DisplayRectangle.Height / MatheMage.Properties.Resources.ChooseMenu.Height;
        
    if(keepAspectratio)
    {
        // If aspect ratio shall be kept: choose the smaller scale for both dimensions
        if(widthRatio > heightRatio)
        {
            widthRatio = heightRatio;
        }
        else
        {
            heightRatio = widthRatio;
        }
    }
    
    // Scale the graphics object.
    e.Graphics.ScaleTransform(widthRatio, heightRatio);
    
    // Draw your stuff as before.
    e.Graphics.DrawImage(MatheMage.Properties.Resources.ChooseMenu, 0, 300);
    //finally restor the old transformation state of the graphics object.
    e.Graphics.Restore(transState);
