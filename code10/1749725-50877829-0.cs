    protected List<T> FilterUsers<T>(List<T> users, SearchViewModel<T, EnumUserSort> search) where T: AugInfo
    {
        if (!string.IsNullOrEmpty(search.SearchString))
        {
            users = users.Where(d => 
                d.Email.ToLower().Contains(search.SearchString.ToLower())
                    || d.Name.ToString().Contains(search.SearchString) 
                    || d.Company.ToString().ToLower().Contains(search.SearchString.ToLower())).ToList();
        }
        return users;
    }
