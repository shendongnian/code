private string password;
public string Password
{
    // Called when being set by a deserializer or a persistence
    // framework
    deserialize
    {
       // I could put some backward-compat hacks in here. Like
       // weak passwords are grandfathered in without blowing up
       this.password = value;
    }
    get
    {
       if (Thread.CurrentPrincipal.IsInRole("Administrator"))
       {
           return this.password;
       }
       else
       {
           throw new PermissionException();
       }
    }
    set
    {
       if (MeetsPasswordRequirements(value))
       {
           throw new BlahException();
       }
       this.password = value;
    }
    serialize
    {
        return this.password;
    }
}
