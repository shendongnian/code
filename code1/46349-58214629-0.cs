    private readonly Dictionary<string, Expression<Func<IuInternetUsers, object>>> _sortColumns = 
            new Dictionary<string, Expression<Func<IuInternetUsers, object>>>()
        {
            { nameof(ContactSearchItem.Id),             c => c.Id },
            { nameof(ContactSearchItem.FirstName),      c => c.FirstName },
            { nameof(ContactSearchItem.LastName),       c => c.LastName },
            { nameof(ContactSearchItem.Organization),   c => c.Company.Company },
            { nameof(ContactSearchItem.CustomerCode),   c => c.Company.Code },
            { nameof(ContactSearchItem.Country),        c => c.CountryNavigation.Code },
            { nameof(ContactSearchItem.City),           c => c.City },
            { nameof(ContactSearchItem.ModifiedDate),   c => c.ModifiedDate },
        };
        private IQueryable<IuInternetUsers> SetUpSort(IQueryable<IuInternetUsers> contacts, string sort, string sortDir)
        {
            if (string.IsNullOrEmpty(sort))
            {
                sort = nameof(ContactSearchItem.Id);
            }
            _sortColumns.TryGetValue(sort, out var sortColumn);
            if (sortColumn == null)
            {
                sortColumn = c => c.Id;
            }
            if (string.IsNullOrEmpty(sortDir) || sortDir == SortDirections.AscendingSort)
            {
                contacts = contacts.OrderBy(sortColumn);
            }
            else
            {
                contacts = contacts.OrderByDescending(sortColumn);
            }
            return contacts;
        }
