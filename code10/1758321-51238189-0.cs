    public class Company
    {
        public Guid Id { get; set; }
    
        public string Name { get; set; }
    
        public CompanyInfo Info { get; set; }
    
        public IEnumerable<Uri> Info_Images { 
          get {
             return Info.Images;
          }
          set {
             if (Info == null) {
                Info = new CompanyInfo();
             }
             Info.Images = value 
          }
        }
        // etc., with the other properties.
    }
    
    public class CompanyInfo
    {
        public IEnumerable<Uri> Images { get; set; }
    
        public string State { get; set; }
    
        public IEnumerable<string> Industries { get; set; }
    
        public string Overview { get; set; }
    }
