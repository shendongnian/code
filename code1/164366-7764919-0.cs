            float[, ,] matches = imgMatch.Data;
            for (int y = 0; y < matches.GetLength(0); y++)
            {
                for (int x = 0; x < matches.GetLength(1); x++)
                {
                    double matchScore = matches[y, x, 0];
                    if (matchScore > 0.75)
                    {
                       Rectangle rect = new Rectangle(new Point(x,y), new Size(1, 1));
                       imgSource.Draw(rect, new Bgr(Color.Blue), 1);
                    }
                }
            }
