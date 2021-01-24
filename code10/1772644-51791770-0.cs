        public async Task<IEnumerable<Intermediary>> GetTest(string company)
        {
            using (var context = new SibaCiidDbContext())
            {
                return
                    await context.Intermediary
                            .Where(query => query.CompanyCode == company)
                            .Select(result =>
                    new Intermediary
                    {
                        CODE = result.CompanyCode,
                        NAME = result.FullName
                    })
                    .ToListAsync();
            }
        }
