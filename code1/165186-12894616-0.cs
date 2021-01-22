    public bool IsImageTransparent(Bitmap image,string optionalBgColorGhost)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    var pixel = image.GetPixel(i, j);
                    if (pixel.A != 255)
                        return true;
                }
            }
            //Check 4 corners to check if all of them are with the same color!
            if (!string.IsNullOrEmpty(optionalBgColorGhost))
            {
                if (image.GetPixel(0, 0).ToArgb() == GetColorFromString(optionalBgColorGhost).ToArgb())
                {
                    if (image.GetPixel(image.Width - 1, 0).ToArgb() == GetColorFromString(optionalBgColorGhost).ToArgb())
                    {
                        if (image.GetPixel(0, image.Height - 1).ToArgb() ==
                            GetColorFromString(optionalBgColorGhost).ToArgb())
                        {
                            if (image.GetPixel(image.Width - 1, image.Height - 1).ToArgb() ==
                                GetColorFromString(optionalBgColorGhost).ToArgb())
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static Color GetColorFromString(string colorHex)
        {
            return ColorTranslator.FromHtml(colorHex);
        }
