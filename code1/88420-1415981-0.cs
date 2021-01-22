    //Model Layer
    public class UserModel
    {
    public virtual string Firstname{get;set;}
    }
    //DataAccess Layer
    public class UserDao
    {
    List<UserModel> GetAll();
    }
    //BusinessLayer
    public class UserDomainModel:UserModel
    {
    public UserDomainModel(UserModel user,UserDao dao)
    {
    _user=user;
    _dao=dao;
    }
    public override string FirstName
    {
    get
    {
    return _user.FirstName;
    }
    set
    {
    _user.FirstName=value;
    }
    
    public void Save()
    {
    _dao.Save(_user);
    }
    }
    }
