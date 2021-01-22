                    if (rotation == 90 || rotation == 270)
                    {
                        if (rotation == 90)
                        {
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(pagenumber).Height);
                        }
                        if (rotation == 270)
                        {
                            cb.AddTemplate(page, 0, 1.0F, -1.0F, 0, reader.GetPageSizeWithRotation(pagenumber).Width, 0);
                        }
     
                    }
                    else
                    {
                        cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                    }
