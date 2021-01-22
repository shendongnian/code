    public const long READ_EMPL_DATA = 0x01
    ...
    {
        User user = database.GetSomeUser();
        // test for READ_EMPL_DATA access
        if (0 != (user.ACL & READ_EMPL_DATA)) {
            // access granted
        } else {
            // access denied
        }
        // give READ_EMPL_DATA access
        if (0 != (user.ACL & READ_EMPL_DATA))
            user.ACL = user.ACL & READ_EMPL_DATA
    }
