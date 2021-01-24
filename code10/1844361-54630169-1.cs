        private static void AddWhaterMark(Texture2D texture, Texture2D whatermarkTexture)
        {
            Color[] originalPixels = texture.GetPixels();
            Color[] whatermarkPixels = whatermarkTexture.GetPixels();
            
            Color[] newPixels = new Color[originalPixels.Length];
            for(int i=0; i < originalPixels.Length; i++)
            {
                Color whatermakPixel = whatermarkPixels[i];
                // adjust the alpha value for the whatermark
                whatermakPixel.a *= 0.5f;
                // combine both Color values
                newPixels[i] = originalPixels[i] + whatermakPixel;
            }
            
            texture.SetPixels(newPixels);
            texture.Apply();
        }
        
