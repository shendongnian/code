    namespace SPI { 
     
        class CompaniesDB 
        { 
            private DataContainer db;
            public CompaniesDB(string name)
            {
                db = new DataContainer(name);
            }
     
            public Company Select(int companyID) { 
                return this.db.Company_Get(companyID).SingleOrDefault(); 
            } 
        } 
    }
