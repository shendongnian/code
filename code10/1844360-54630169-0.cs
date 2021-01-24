        private static void AddWhaterMark(Texture2D texture, Texture2D whatermarkTexture)
        {
            var originalPixels = texture.GetPixels();
            var whatermarkPixels = whatermark.GetPixels();
            
            Color[] newPixels = new Color[originalPixels.Length];
            for(int i=0; i < originalPixels.Length; i++)
            {
                var whatermakPixel = whatermarkPixels[i];
                // adjust the alpha for the whatermark
                whatermakPixel.a = 0.5f;
                newPixels[i] = originalPixels[i] + whatermakPixel;
            }
            
            texture.SetPixels(newPixels);
            texture.Apply();
        }
        
