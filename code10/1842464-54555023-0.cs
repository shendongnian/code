    class CustomerClass
    {
        public string Name {get; set;}
        public string Surname {get;set;}
    }
    
    class MainClass
    {
         public CustomerClass Customer {get; set;}
    }
****
    class MainClassDto
    {
        public string CustomerName {get; set;}
        public string CustomerSurname {get; set;}
    
    }
