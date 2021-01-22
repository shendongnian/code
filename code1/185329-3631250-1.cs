    class CompanyFile{
         public string CompanyName {get;set;}
         public string Filename {get;set;}
         public string OriginalFilename {get;set;}
    }
    class Company{
         public string CompanyName {get;set;}
         public List<string> FileNames {get;set;}
    }
