    using Leadtools;
    using Leadtools.Codecs;
    using Leadtools.ImageProcessing.Core;
    using Leadtools.Ocr;
    using System;
    using System.Linq;
    
    namespace FindFirstZone
    {
        class Program
        {
            static IOcrEngine ocrEngine;
            static RasterCodecs codecs;
    
            static void Main(string[] args)
            {
                Initialize();
                var image = codecs.Load(@"randomtext.png");
                LeadRect rect = FindFirstZone(image);
                DoOcr(image, rect);
                Console.ReadLine();
            }
    
            static void Initialize()
            {
                RasterSupport.SetLicense(@"C:\LEADTOOLS 20\Common\License\LEADTOOLS.LIC",
                    System.IO.File.ReadAllText(@"C:\LEADTOOLS 20\Common\License\LEADTOOLS.LIC.KEY"));
    
                codecs = new RasterCodecs();
    
                ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false);
                ocrEngine.Startup(null, null, null, null);
            }
    
            static LeadRect FindFirstZone(RasterImage img)
            {
                AutoZoningCommand autoZoningCommand = new AutoZoningCommand(
                    AutoZoningOptions.DetectAccurateZones |
                    AutoZoningOptions.DetectText |
                    AutoZoningOptions.DontAllowOverlap);
                autoZoningCommand.Run(img);
    
                if (autoZoningCommand.Zones != null && autoZoningCommand.Zones.Count > 0)
                {
                    var sortedList = autoZoningCommand.Zones.OrderBy(z => z.Bounds.Top)
                        .ThenBy(z => z.Bounds.Left).ToList();
                    return sortedList[0].Bounds;
                }
                else
                    throw new Exception("No Zones");
            }
    
            static void DoOcr(RasterImage image, LeadRect rect)
            {
                using (var ocrPage = ocrEngine.CreatePage(image, OcrImageSharingMode.None))
                {
                    ocrPage.Zones.Add(new OcrZone()
                    {
                        Bounds = rect,
                        ZoneType = OcrZoneType.Text,
                    });
                    ocrPage.Recognize(null);
                    Console.WriteLine(ocrPage.GetText(-1));
                }
            }
        }
    }
