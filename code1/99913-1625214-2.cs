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
               try
                {
            Presentation = presentations.Open(file, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
    
                // Voor elke slide, exporteren
                // ...
    
                // Elke slide exporteren
                var slides = Presentation.Slides;
    
                foreach (Slide slide in slides)
                {
                    slide.Export(Path.Combine(exportSlidesPath, "slide_" + slide.SlideIndex + ".png"), "PNG", 1024, 768);
                    Marshal.ReleaseComObject(slide);
                }
      Marshal.ReleaseComObject(presentations);
            Marshal.ReleaseComObject(slides);
    
            Presentation.Close();
            Marshal.FinalReleaseComObject(Presentation);
             }
            catch (System.Exception err){}
            finally{
           
           // GC.WaitForPendingFinalizers();    
    
            PP.Quit();
            Marshal.FinalReleaseComObject(PP);
            GC.Collect();
          } 
     } } }
