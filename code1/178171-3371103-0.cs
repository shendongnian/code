    [Flags]
    public Enum Permissions
    {
      None =0,
      Read = 1,
      Write =2,
      Delete= 4
    }
    Permissions p = Permissions.Read | Permissions.Write;
    p.ToString() //Prints out "Read, Write"
