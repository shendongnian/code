    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using Powerpoint = Microsoft.Office.Interop.PowerPoint;
    using Microsoft.Office.Core;
    using Microsoft.Office.Interop.PowerPoint;
    using System.Runtime.InteropServices;
    
    namespace PresentrBuilder
    {
    class PowerpointConverter
    {
    public static void Convert(String file, String safeFile)
    {
        Powerpoint.Application PP;
        Powerpoint.Presentation Presentation;
        PP = new Powerpoint.ApplicationClass();
        PP.Visible = MsoTriState.msoTrue;
        PP.WindowState = Microsoft.Office.Interop.PowerPoint.PpWindowState.ppWindowMinimized;
        var presentations = PP.Presentations;
        Presentation = presentations.Open(file, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            // Voor elke slide, exporteren
            String exportSlidesPath = Path.Combine(Properties.Settings.Default.CacheDir, @"presentatienaam1\slides");
            // Kijk of de directory bestaat
            if (!Directory.Exists(exportSlidesPath))
            {
                Directory.CreateDirectory(exportSlidesPath);
            }
                // Kijk of er al bestanden in de directory staan
                // Zo ja: verwijderen
                String[] files = Directory.GetFiles(exportSlidesPath, "*.png");
                if (files.Length > 0)
                {
                    foreach (string fileName in files)
                    {
                        File.Delete(Path.Combine(exportSlidesPath, fileName));
                    }
                }
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
