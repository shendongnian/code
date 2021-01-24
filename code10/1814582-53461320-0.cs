                    WriteableBitmap WBM = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
                    byte[] pixels = new byte[width * height * 4];
                    double perColour = (double)(max - min) / 254d;
                    Color[] ca = Application.Current.Resources["HypsoColours"] as Color[];
                    int ix = 0;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            int elv = elevations[x, y];
                            int eff = elv - min;
                            int ptr = 0;
                            if (eff> 0)
                            {
                                ptr = (int)((elv - min) / perColour);
                            }
                            Color colour = ca[ptr];
                            pixels[ix] = colour.B;
                            ix++;
                            pixels[ix] = colour.G;
                            ix++;
                            pixels[ix] = colour.R;
                            ix++;
                            pixels[ix] = 255;
                            ix++;
                        }
                    }
                    WBM.WritePixels(new Int32Rect(0, 0, width, height), pixels, width * 4, 0);
                    WBM.Freeze();
                    return WBM;
