     public class BusinessRepository :IBusinessRepository
        {
            private readonly AppContext _context;
    
            public BusinessRepository(AppContext context)
            {
                _context = context;
            }
    
            // working
            public IEnumerable<Business> GetBusiness(int id)
            {
                 var query = @"exec query.usp_GetBusiness @id";
                 var p1 = new SqlParameter("@id", id);
                 return _context.Business.FromSql(query, p1).ToList();
            }
            // working
            public void UpdateBusinessName(string name, string user)
            {
                _context.Database.ExecuteSqlCommand("exec command.usp_UpdateBusinessName @user, @name",
                    new SqlParameter("user", user),
                    new SqlParameter("name", name)
                );
            }
    }
