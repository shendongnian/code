        minfo = b.GetType().GetMethods("publicProtectedMember", 
    BindingFlags.Instance|BindingFlags.NonPublic |BindingFlags.Public);
                    if (minfo.IsFamily || minfo.IsPublic)
                    {
                        string s = fd.Member();
                    }
