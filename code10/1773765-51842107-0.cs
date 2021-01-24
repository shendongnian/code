    public class User
    {
        public int Id
        public virtual ICollection<Company> Companies { get; set; }
        public int ActiveCompanyId { get; set; }
        [NotMapped]
        public Company ActiveCompany
        {
            get
            {
              return this.Companys == null ? null :
                          Companies.Where(x => x.Id == this.Active.CompanyId)
                                   .SingleOrDefault;
            }
        }
        public User()
        {
           this.Companies = new HashSet<Company>();
        }
    }
