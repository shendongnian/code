            Microsoft.Office.Interop.PowerPoint.Application powerpoint;
            Microsoft.Office.Interop.PowerPoint.Presentation presentation;
            Microsoft.Office.Interop.PowerPoint.Presentations presentations;
            powerpoint = new Microsoft.Office.Interop.PowerPoint.ApplicationClass();
            powerpoint.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            presentations = powerpoint.Presentations;
            presentation = presentations.Open(localPath, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            //String presentationTitle = objPres.Name;
            Microsoft.Office.Interop.PowerPoint.Slides slides = presentation.Slides;
            **for (int i = 1; i <= slides.Count; i++)
            {
                Microsoft.Office.Interop.PowerPoint.Slide slide = slides[i];
                String slideName = slide.Name;
                releaseCOM(slide);
            }**
