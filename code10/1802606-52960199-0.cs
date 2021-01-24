    string s;
    bool inRewriteBlock = false;
    while ((s = sr.ReadLine()) != null)
    {
        if (s == "#Start")
        {
            inRewriteBlock = true;
        }
        else if (s == "#End")
        {
            inRewriteBlock = false;
        }
        else if (inRewriteBlock)
        {
            sw.WriteLine(s);
            //need something here to overwrite existing data with s not just add s
        }
        else
        {
            sw.WriteLine(s);
        }
    }
