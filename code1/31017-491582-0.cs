    var query = /* your primary query */
    if(!string.IsNullOrEmpty(name)) {
        query = query.Where(row => row.Name == name);
    }
    if(activeOnly) {
        query = query.Where(row => row.IsActive);
    }
