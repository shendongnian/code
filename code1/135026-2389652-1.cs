    using(SvnClient client = new SvnClient())
    {
       SvnAddArgs aa = new SvnAddArgs();
       aa.Depth = SvnDepth.Infinity;
       aa.Force = true;
       client.Add(rootDir, aa);
    }
