    [Authorize(Roles = "CompanyAdmin")]
    public ActionResult Index(string UserId)
    {
        if (UserId == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        
        //Trying to get a view model for customer from the received UserId.
        CompanyOverview modelInstance = CompanyOverview.GetCompanyByUser(UserId, db);
        if (modelInstance == null)
        {
            return HttpNotFound();
        } 
        return View(modelInstance);
    }
    //From your question I'm taking this class as a ViewModel only
    public partial class CompanyOverview
    {
        //Keeping it here just because you implemented it (if not used elsewhere, just remove this)
        public CompanyOverview()
        {
            AddressDetail = new List<Addresses>();
        }
        //Static method to get an instance of your model when given an userId and DbContext instance. Correct the DbContext type name in the below parameter.
        public static CompanyOverview GetCompanyByUser(int userId, YourDbContext db)
        {
            var qCus = from ad in db.Addresses
                          join ua in db.UsersToAddresses on ad.AddressID equals ua.AddressId
                          join cus in db.CustomerNames on ua.CustomerId equals cus.CustomerId
                          where (ua.UserId == userId)
                          select new CompanyOverview() {
                              UserId = userId,
                              AddressId = ad.AddressId,
                              CustomerName = cus
                          };
            var result = qCus.SingleOrDefault();
            if (result != null) 
            {
                result.AddressDetail = db.Addresses.Where(a => a.CustomerId == result.CustomerName.CustomerId)
            }
            return result;
        }
        //[Key] <- You don't need to define a Key annotation, since this will only be a ViewModel (thus, not having persistence by EF).
        public string UserId { get; set; }
        public string AddressId { get; set; }
        public virtual CustomerNames CustomerName { get; set; }
        public virtual ICollection<Addresses> AddressDetail { get; set; }
    }
