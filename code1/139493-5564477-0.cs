                        word = (MODI.Word)layout.Words[l];
                        for (int j = 0; j < word.Rects.Count; j++)
                        {
                            MODI.MiRect rect = (MODI.MiRect)word.Rects[j];
                            if (j == 0)
                            {
                                top = rect.Top;
                            }
                            if (height == 0 || height < (rect.Bottom - rect.Top))
                                height = rect.Bottom - rect.Top;
                            width = rect.Right - rect.Left;
                            right = rect.Left + width;
                            top = rect.Top;
                            left = rect.Left;
                        }
                        OCRDocWord ocrword = new OCRDocWord(top, left, width, height, word.Text);
                        width = 0;
                        wordlist.Add(ocrword);
