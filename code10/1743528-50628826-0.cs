                            if (assess5 < 3 && assess50 < 10) 
                            {
                                builder.Append(" Green");
                                oRng.Font.Color = XlRgbColor.rgbGreen;
                                FontChecker = 0;
                            }
                            if (assess5 >= 3 && assess50 <= 10)
                            {
                                builder.Append(" Orange");
                                oRng.Font.Color = XlRgbColor.rgbOrange;
                                FontChecker = 0;
                            }
                            if (assess5 > 3 && assess50 > 10)
                            {
                                builder.Append(" Red");
                                oRng.Font.Color = XlRgbColor.rgbRed;
                                FontChecker = 0;
                            }
                            if (assess5 < 3 && assess50 >= 10) // StackExchange answer.
                            {
                                builder.Append(" Red");
                                oRng.Font.Color = XlRgbColor.rgbRed;
                                FontChecker = 0;
                            }
