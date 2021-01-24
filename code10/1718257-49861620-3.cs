        static void InitRGBA_Alpha(int pixelCount, byte[] rgbaData)
        {
            for (int i = 0; i < pixelCount; i++)
            {
                rgbaData[i * 4 + 3] = 255;
            }
        }
