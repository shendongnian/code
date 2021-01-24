    Microsoft.Office.Interop.PowerPoint.Application ppt = new Microsoft.Office.Interop.PowerPoint.Application();
    ppt.Visible = MsoTriState.msoTrue;
    ppt.WindowState = Microsoft.Office.Interop.PowerPoint.PpWindowState.ppWindowMinimized;
    source = ppt.Presentations.Open(filename);
    target = ppt.Presentations.Open(targetname, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoTrue);
    sourceSlideRange = source.Slides.Count;
   
    for (int i = 3; i < sourceSlideRange; i++)
        {
          source.Slides[i].Delete();
          source.Save();
        }
                
    source.Close();
 
