    public ActionResult ExportPDF(string orderId)
        {
            try
            {
                return View("ConfirmPDFReport", new {orderId = orderId });
               
            }
            catch (Exception e)
            {
                return RedirectToAction("GeneralError", "Error", new { ErrorMessage = e.Message });
            }
        }
     public ActionResult ConfirmPDFReport(string orderId)
    {
        try
        {
            return new ActionAsPdf("ConfirmationPDF", FlightSearchSession) 
           {
                    FileName = DateTime.Now.ToString() + "FlightTicketInfo.pdf"
                ,
                    PageOrientation = Orientation.Landscape
                ,
                    MinimumFontSize = 18
                };
        }
        catch (Exception e)
        {
            return RedirectToAction("GeneralError", "Error", new { ErrorMessage = e.Message, parameter = "OrderId=" + orderId });
        }
    }
