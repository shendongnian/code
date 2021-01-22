    var minfo = b.GetType().GetMethod("publicProtectedMember", 
        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    if (minfo.IsFamily || minfo.IsPublic)
    {
         string s = fd.Member();
    }
