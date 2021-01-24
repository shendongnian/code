    public class CustomerResult
    {
       public string CompanyStatus { get; set; }
       public OverallResult Result { get; set; }
    }
    public class OverallResult
    {
       public OverallResult()
       {
           StatusCode = 55;
           StatusDescription = "Nothing to see";
       }
       public OverallResult(int statusCode, string status)
       {
          StatusCode = statusCode;
          StatusDescription = status;
       }
       public string StatusDescription { get; set; }
       public int StatusCode { get; set; }
       public string CustomerId { get; set; }        
    }
    void main()
    {
       var result = new CustomerResult()
       {
           Result = new OverallResult(51, "Blah"),
       };
    }
