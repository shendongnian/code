    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace App1.Database
    {
        public class Account
        {
            public int    Id   { get; set; }
            public string User { get; set; }
            public string Pass { get; set; }
        }
    
        public class App1Db : Microsoft.EntityFrameworkCore.DbContext
        {
            Microsoft.EntityFrameworkCore.DbSet<Account> Account;
        }
    }
