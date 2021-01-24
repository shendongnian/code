    public ActionResult HomePage()
    {
        string name = "John";
        ChangeName(ref name);
        string newName = name ; -- This is now Scott.
    }
    public static void ChangeName(ref string myname)
    {
      myname = "Scott";
    }
