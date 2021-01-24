    private Repository _Repository;
    private Repository Repository
    {
        get 
        {
            _Repository.InjectUsername(User.Identity.Name); // value is already available here
            return _Repository;
        }
        set
        {
            _Repository = new Repository();
        }
    }
