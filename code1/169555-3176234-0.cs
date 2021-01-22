    using (RichEditControl richEditControl = new RichEditControl()) {
        richEditControl.LoadDocument(Server.MapPath(@".\teste.htm"), DocumentFormat.Html);
        using (PrintingSystem ps = new PrintingSystem()) {
            PrintableComponentLink pcl = new PrintableComponentLink(ps);
            pcl.Component = richEditControl;
            pcl.CreateDocument();
            //pcl.PrintingSystem.ExportToPdf("teste.pdf");
            pcl.PrintingSystem.ExportToImage("teste.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
