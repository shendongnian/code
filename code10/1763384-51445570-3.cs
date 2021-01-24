    public async Task<IActionResult> Index()
    {
        var pdf = new Rotativa.AspNetCore.ViewAsPdf("Index")
        {
            FileName = "C:\\Test.pdf",
            PageSize = Rotativa.AspNetCore.Options.Size.A4,
            PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
            PageHeight = 20,
        };
        var byteArray = await pdf.BuildFile(ControllerContext);
        return File(byteArray, "application/pdf");
    }
