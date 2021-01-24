                                MSPPT.Slide slide = pprst.Slides[s];
                                int shapeCount = slide.Shapes.Count;
                                for (int h = 1; h <= shapeCount; ++h)
                                {
                                    MSPPT.Shape shape = slide.Shapes[h];
                                    if (shape.HasTextFrame == MsoTriState.msoTrue)
                                    {
                                        if (shape.TextFrame2.HasText == MsoTriState.msoTrue)
                                        {
                                            shape.TextFrame2.TextRange.Font.Spacing = 0;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
