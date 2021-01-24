      string info = e.CommandArgument.ToString();
        string[] arg = new string[2];
        char[] splitter = { ';' };
        arg = info.Split(splitter);
        int Code=Convert.ToInt32(arg[0]);
        Guid ID=Guid.Parse(arg[1]);
