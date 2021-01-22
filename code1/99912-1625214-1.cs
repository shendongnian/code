    // removed using statements...
    
    namespace PresentrBuilder
    {
      class PowerpointConverter
      {
      public static void Convert(String file, String safeFile)
      {
        Powerpoint.Application PP;
        Powerpoint.Presentation Presentation;
        PP = new Powerpoint.ApplicationClass();
        // ...
        var presentations = PP.Presentations;
        Presentation = presentations.Open(file, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            // Voor elke slide, exporteren
            // ...
            // Elke slide exporteren
            var slides = Presentation.Slides;
            foreach (Slide slide in slides)
            {
                slide.Export(Path.Combine(exportSlidesPath, "slide_" + slide.SlideIndex + ".png"), "PNG", 1024, 768);
                Marshal.ReleaseComObject(slide);
            }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Marshal.ReleaseComObject(presentations);
        Marshal.ReleaseComObject(slides);
        Presentation.Close();
        Marshal.FinalReleaseComObject(Presentation);
        PP.Quit();
        Marshal.FinalReleaseComObject(PP);
    } } }
