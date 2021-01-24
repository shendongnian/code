     public class AddTenantRequestdto
    {
        public IFormFile TenantLogo { get; set; }    
        public string TenantTitle { get; set; } 
        public List<string> ApplicationName { get; set; }  
        public bool EnableOTP { get; set; }
        
    }
