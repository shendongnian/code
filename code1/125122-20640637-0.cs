        private string GetNotes(Slide slide)
        {
            if (slide.HasNotesPage == MsoTriState.msoFalse)
                return string.Empty;
            
            string slideNodes = string.Empty;
            var notesPage = slide.NotesPage;
            int length = 0;
            foreach (Shape shape in notesPage.Shapes)
            {
                if (shape.Type == MsoShapeType.msoPlaceholder)
                {
                    var tf = shape.TextFrame;
                    try
                    {
                        //Some TextFrames do not have a range
                        var range = tf.TextRange;
                        if (range.Length > length)
                        {   //Some have a digit in the text, 
                            //so find the longest text item and return that
                            slideNodes = range.Text;
                            length = range.Length;
                        }
                        Marshal.ReleaseComObject(range);
                    }
                    catch (Exception)
                    {}
                    finally
                    { //Ensure clear up
                        Marshal.ReleaseComObject(tf);
                    }
                }
                Marshal.ReleaseComObject(shape);
            }
            return slideNodes;
        }
