        public class PDFController : Controller
        {
                public Byte[]  getPDF()
                {
                var actionPDF = new Rotativa.ViewAsPdf("YOUR_VIEW_NAME") )
                {
                    
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Landscape,
                   PageMargins = { Left = 1, Right = 1 }
                };
                byte[] applicationPDFData = actionPDF.BuildPdf(this.ControllerContext);
                return applicationPDFData;
            }
       }
