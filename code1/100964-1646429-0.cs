    private UsersRepository _usersRepository;
    private  UsersRepository UsersRepository
    {
        get
        {
            if(_usersRepository == null)
            {
                _usersRepository = new UsersRepository();
            }
            return _usersRepository;
        }
    }
