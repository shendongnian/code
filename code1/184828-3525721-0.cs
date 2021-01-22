    [WebMethod]
    public void CreatePdfIncomeTax(IncomeTaxForm itf)
    {
        // integrate with Cete Pdf Merger 
        string fileName = SomePdfMerging(itf);
        byte[] pdfBytes = ReadFileFromDisk(fileName);
        Response.BinaryWrite(pdfBytes);
        Response.End();
    }
    
    private byte[] ReadFileFromDisk()
    {
        byte[] pdfBytes = null;
        using (FileStream fs = File.OpenRead(fileName))
        {
          pdfBytes= new byte[fs.Length];
          fs.Read(pdfBytes, (int)0, (int)fs.Length);
        }
        return pdfBytes;
    }
    ...
    // a class that the caller would populate as param to the webmethod
    public class IncomeTaxForm 
    {
       public string FirstName {get;set;}
       public string AddressLine1 {get;set;}
       ...
    }
