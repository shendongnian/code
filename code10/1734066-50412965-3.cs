        public IQueryable<Invoice> BuildQuery(InvoiceSpecification specification, IQueryable<Creditor> query)
        {
            if (!string.IsNullOrWhiteSpace(specification.Query))
            {
                var search = specification.Query.ToLower().Trim();
                query = query.Where(c => c.OfficeEmail.Contains(search)
                    || c.OfficePhone.Contains(search)
                    || c.CompanyRegistrationNumber.Contains(search)
                    || c.CompanyName.Contains(search)
                    || c.LastName.Contains(search)
                    || c.FirstName.Contains(search));
            }
            if (!string.IsNullOrWhiteSpace(specification.CompanyRegistrationNumber))
            {
                var search = specification.CompanyRegistrationNumber.ToLower().Trim();
                query = query.Where(c => c.CompanyRegistrationNumber == search);
            }
            if (specification.UpdateFrequency.HasValue)
            {
                query = query.Where(c => c.UpdateFrequency == specification.UpdateFrequency.Value);
            }
            return query.Where(c => !c.DateDeleted.HasValue);
        }
