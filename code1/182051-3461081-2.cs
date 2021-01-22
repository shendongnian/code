    IEnumerable<Rectangle> FindImageTiles(Bitmap compositeImage)
    {
        var result = new List<Rectangle>();
        // Scan for a non-empty region that hasn't already been "captured"
        for (var x = 0; x < compositeImage.Width; x++)
        {
            for (var y = 0; y < compositeImage.Height; y++)
            {
                // Only process the pixel if we don't have a rectangle that
                // already contains this and if it's not empty
                if (!result.Any(r => r.Contains(x, y)) 
                    && compositeImage.GetPixel(x, y).A != 0)
                {
                    // Now that we've found a point, create a rectangle
                    // surrounding that point, then expand outward until
                    // we have a bounding rectangle that doesn't intersect
                    // with the tile
                    var rect = new Rectangle(x - 1, y - 1, 2, 2);
                    bool foundBounds = false;
                    while (!foundBounds)
                    {
                        var xRange = Enumerable.Range(rect.Left, rect.Right)
                            .Where(px => px >= 0 && px < compositeImage.Width);
                        var yRange = Enumerable.Range(rect.Top, rect.Bottom)
                            .Where(py => py >= 0 && py < compositeImage.Height);
                        // Adjust the top
                        if (rect.Top >= 0 
                            && xRange
                                .Select(bx => compositeImage.GetPixel(bx, rect.Top))
                                .Any(p => p.A != 0))
                        {
                            rect.Y--;
                            rect.Height++;
                        }
                        else if (rect.Bottom < compositeImage.Height
                            && xRange
                                .Select(bx => compositeImage.GetPixel(bx, rect.Bottom))
                                .Any(p => p.A != 0))
                        {
                            rect.Height++;
                        }
                        else if (rect.Left >= 0
                            && yRange
                                .Select(by => compositeImage.GetPixel(rect.Left, by))
                                .Any(p => p.A != 0))
                        {
                            rect.X--;
                            rect.Width++;
                        }
                        else if (rect.Right < compositeImage.Width
                            && yRange
                                .Select(by => compositeImage.GetPixel(rect.Right, by))
                                .Any(p => p.A != 0))
                        {
                            rect.Width++;
                        }
                        else
                        {
                            foundBounds = true;
                        }
                    }
                    result.Add(rect);
                }
            }
        }
        return result;
    }
