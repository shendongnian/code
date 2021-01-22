    using (SvnRepositoryClient rc = new SvnRepositoryClient())
    {
       SvnSetRevisionPropertyRepositoryArgs ra;
       ra.CallPreRevPropChangeHook = false;
       ra.CallPostRevPropChangeHook = false;
       rc.SetRevisionProperty(@"C:\Path\To\Repository", 12345,
                             SvnPropertyNames.SvnAuthor, "MyName", ra);
    }
