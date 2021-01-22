        public List<string> Countries()
        {
            return Customers.Get(
                x=>x.CompanyName != "",
                x=>x.Country,
                x=>x).Distinct().ToList();
        }
