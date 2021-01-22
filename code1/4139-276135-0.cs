    public class UserInfo
    {
     [Category("Must change")]
     public string Name { get; set; }
    }
    
    public class NewUserInfo : UserInfo
    {
     public NewUserInfo(UserInfo user)
     {
     // transfer all the properties from user to current object
     }
    
     [Category("Changed")]
     public new string Name {
    get {return base.Name; }
    set { base.Name = value; }
     }
    
    public static NewUserInfo GetNewUser(UserInfo user)
    {
    return NewUserInfo(user);
    }
    }
    
    void YourProgram()
    {
    UserInfo user = new UserInfo();
    ...
    // Bind propertygrid to object
    grid.DataObject = NewUserInfo.GetNewUser(user);
    ...
    }
    
