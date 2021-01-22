    public interface IReport
    {
       string GetTextReportDocument();
       byte[] GetPDFReportDocument();  // needing this triggers the development of interface
    }
    
    public class SalesReport : IReport
    {
       public void AddSale( Sale newSale )
       {
           this.Sales.Add(newSale);  // or however you implement it
       }
       public string GetTextReportDocument()
       {
           StringBuilder reportBuilder = new StringBuilder();
           var groups = from row in this.Sales
                        group row by row.SomeTime.Date;
           foreach (var group in groups.OrderBy(group => group.Key))
           {            
              reportBuilder.AppendLine(group.Key);
              foreach(var item in group.OrderBy(item => item.SomePrice))            
              {
                 reportBuilder.AppendLine(item.SomePrice);
              }
              reportBuilder.AppendLine("Total" + group.Sum(x=>x.SomePrice));
          }
          return reportBuilder.ToString();
       }
    
       public byte[] GetPDFReportDocument()
       {
            return PDFReporter.GenerateDocumentFromXML( this.ConvertSalesToXML() );
       }
