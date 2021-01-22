    using OpenNETCF.Globalization;
    ....
    static void Main()
    {
        foreach (CultureInfo ci in CultureInfoHelper.GetCultures())
        {            
            Debug.WriteLine(string.Format("0x{0:x2}({1}) : {2}", ci.LCID, ci.Name, ci.EnglishName));
        }
    }
