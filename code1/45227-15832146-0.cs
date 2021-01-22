    foreach (PowerPoint.Slide slide in presentation.Slides)
    {
                        slide.Select();
                        foreach (PowerPoint.Shape shape in slide.Shapes)
                        {
                            if (shape.Type.ToString().Equals("<any type of shape>"))
                            {
                                if (shape.TextFrame.TextRange.Text.Equals("<contains a name"))
                                {
                                    shape.TextFrame.TextRange.Text = <new value>;
                                    shape.Delete(); // or delete
                                    shape.AddPicture(<your new picture>, MsoTriState.msoTrue, MsoTriState.msoTrue, left, top, width, height);
                                                    
                                }
                            }
                        }
