    public IActionResult ImageDownload()
    {
        HttpContext.JsReportFeature().Recipe(Recipe.PhantomPdf)
            .Configure((r) => r.Template.Phantom = new Phantom
            {
                Format = PhantomFormat.A4,
                Orientation = PhantomOrientation.Portrait                 
            }).OnAfterRender( (r) =>
            {
                var streamIo = r.Content; // streamIo  is of type System.IO
                using(var fs = System.IO.File.OpenWrite("C:GeneratedReports\\myReport.pdf"))
                {
                    streamIo.CopyTo(fs);
                }
                streamIo.Seek(0, SeekOrigin.Begin);                 
            }
        );
    
        var dp = new Classes.DataProvider();
        var lstnames = dp.GetRegisteredNames();
        var lst = lstnames.ToArray<string>();
        return View("Users", lst);
    }
