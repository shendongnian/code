        public int GetBySpecification(InvoiceSpecification specification)
        {
            IQueryable<Invoice> query = BuildQuery(specification, _db.Creditors);
            return query.Count();
        }
