    public ActionResult ShowPrinters()
    {
        var printerModel = new PrintSettingsModel();
        printerModel.PrintSettings = new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "Printer1",   //Your printer details from XML
                Value = "Printer1"
             }
         };
                
            return View("ShowPrinter", printerModel);
    }
