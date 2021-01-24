    public class CompanyService
    {
        public List<Company> getCompanyList()
        {
            using (ERPEntities db = new ERPEntities())
            {
                return db.Companies
                         .Include("Contacts")
                         .Where(e => e.Name.Contains("Network"))
                         .Take(10)
                         .ToList();
            }
        }
    }
