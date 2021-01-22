        public Bitmap Crop(Bitmap bitmap)
        {
            int w = bitmap.Width;
            int h = bitmap.Height;
            Func<int, bool> IsAllWhiteRow = row =>
            {
                for (int i = 0; i < w; i++)
                {
                    if (bitmap.GetPixel(i, row).R != 255)
                    {
                        return false;
                    }
                }
                return true;
            };
            Func<int, bool> IsAllWhiteColumn = col =>
            {
                for (int i = 0; i < h; i++)
                {
                    if (bitmap.GetPixel(col, i).R != 255)
                    {
                        return false;
                    }
                }
                return true;
            };
            int leftMost = 0;
            for (int col = 0; col < w; col++)
            {
                if (IsAllWhiteColumn(col)) leftMost = col + 1;
                else break;
            }
            int rightMost = w - 1;
            for (int col = rightMost; col > 0; col--)
            {
                if (IsAllWhiteColumn(col)) rightMost = col - 1;
                else break;
            }
            int topMost = 0;
            for (int row = 0; row < h; row++)
            {
                if (IsAllWhiteRow(row)) topMost = row + 1;
                else break;
            }
            int bottomMost = h - 1;
            for (int row = bottomMost; row > 0; row--)
            {
                if (IsAllWhiteRow(row)) bottomMost = row - 1;
                else break;
            }
            if (rightMost == 0 && bottomMost == 0 && leftMost == w && topMost == h)
            {
                return bitmap;
            }
            int croppedWidth = rightMost - leftMost + 1;
            int croppedHeight = bottomMost - topMost + 1;
            try
            {
                Bitmap target = new Bitmap(croppedWidth, croppedHeight);
                using (Graphics g = Graphics.FromImage(target))
                {
                    g.DrawImage(bitmap,
                        new RectangleF(0, 0, croppedWidth, croppedHeight),
                        new RectangleF(leftMost, topMost, croppedWidth, croppedHeight),
                        GraphicsUnit.Pixel);
                }
                return target;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Values are top={0} bottom={1} left={2} right={3}", topMost, bottomMost, leftMost, rightMost), ex);
            }
        }
