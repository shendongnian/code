    [WebMethod]
    public void CreatePdfIncomeTax(IncomeTaxForm itf)
    {
        // integrate with Cete Pdf Merger 
        string fileName = SomePdfMerging(itf);
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "inline; filename=foo.pdf");
        Response.WriteFile(path);
        Response.Flush();
        Response.End();
    }
    
    ...
    // a class that the caller would populate as param to the webmethod
    public class IncomeTaxForm 
    {
       public string FirstName {get;set;}
       public string AddressLine1 {get;set;}
       ...
    }
