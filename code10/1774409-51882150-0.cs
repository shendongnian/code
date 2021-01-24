    public class HoughMap
    {
        public int[,] houghMap { get; private set; }
        public int[,] image { get; set; }
        public void Compute()
        {
            if (image != null)
            {
                // get source image size
                int Width = image.GetLength(0);
                int Height = image.GetLength(1);
                int centerX = Width / 2;
                int centerY = Height / 2;
                int maxTheta = 180;
                int houghHeight = (int)(Math.Sqrt(2) * Math.Max(Width, Height)) / 2;
                int doubleHeight = houghHeight * 2;
                int houghHeightHalf = houghHeight / 2;
                int houghWidthHalf = maxTheta / 2;
                houghMap = new int[doubleHeight, maxTheta];
                // scanning through each (x,y) pixel of the image--+
                for (int y = 0; y < Height; y++)                 //|
                {                                                //|
                    for (int x = 0; x < Width; x++)//<-------------+
                    {
                        if (image[x, y] != 0)//if a pixel is black, skip it.
                        {
                            // We are drawing some Sine waves.  
                            // It may vary from -90 to +90 degrees.
                            for (int theta = 0; theta < maxTheta; theta++)
                            {
                                double rad = theta *Math.PI / 180;
                                // respective radius value is computed
                                int rho = (int)(((x - centerX) * Math.Cos(rad)) + ((y - centerY) * Math.Sin(rad)));
                                // get rid of negative value
                                rho += houghHeight;
                                // if the radious value is between 
                                // 1 and twice the houghHeight 
                                if ((rho > 0) && (rho <= doubleHeight))
                                {
                                    houghMap[rho, theta]++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
