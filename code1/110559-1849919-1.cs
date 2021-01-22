    public MyWCFClass() : this(new UserDAL())
    {
    }
    public MyWCFClass(IUserDal userDAL)
    {
        _myUserDAL = myUserDAL;
    }
