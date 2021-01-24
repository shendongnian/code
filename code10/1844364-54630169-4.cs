        private static void AddWhaterMark(Texture2D texture, Texture2D whatermarkTexture)
        {
            int whatermarkWidth = whatermarkTexture.width;
            int whatermarkHeight = whatermarkTexture.height;
    
            // In Unity differrent to most expectations the pixel corrdinate
            // 0,0 is not the top-left corner but instead the bottom-left
            // so since you want the whatermark in the top-right corner do
            int startx = texture.width - whatermarkWidth;  
            // optionally you could also still leave a border of e.g. 10 pixels by using
            // int startx = texture.width - whatermarkWidth - 10;
    
            // same for the y axis
            int starty = texture.height - whatermarkHeight;
    
            Color[] whatermarkPixels = whatermarkTexture.GetPixels();
            // get the texture pixels for the given rect
            Color[] originalPixels = texture.GetPixels(startx, starty, whatermarkWidth, whatermarkHeight);
        
            for(int i = 0; i < whatermarkPixels.Length; i++)
            {
                var pixel = whatermarkPixels[i];
                // adjust the alpha value of the whatermark
                pixel.a *= 0.5f;
                // add whatermark pixel to original pixel
                originalPixels[i] += pixel;
            }
        
            // write back the changed texture data
            texture.SetPixels(startx, starty, whatermarkWidth, whatermarkHeight, originalPixels);
            texture.Apply();
        }
