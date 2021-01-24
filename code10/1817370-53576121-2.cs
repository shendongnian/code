    static class Roles 
    {
    public RoleType Role;
    public enum RoleType 
    {
    //your role types
    }
    }
    
    private void btnLogin_Click(object sender, EventArgs e) 
    {
    switch(i)
    {
    case 1: { Roles.RoleType = Roles.RoleType.practiceManager; break; }
    //rest of cases...
    }
    }
