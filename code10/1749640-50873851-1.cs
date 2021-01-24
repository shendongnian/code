    public IEnumerable<User> SearchByName(string name)
    {
           //this doesn't access the result
           return _userRepositoryDal.SearchByName(name);
           //this would
           //return _userRepositoryDal.SearchByName(name).ToList();
    }
