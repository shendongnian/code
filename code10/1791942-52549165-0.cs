    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace TimePlus.Data
    {
        public class ApplicationUser : IdentityUser
        {
            public string Fullname { get; set; }
            public int? CompanyID { get; set; }
            public int? EmployeeID { get; set; }
        }
    }
