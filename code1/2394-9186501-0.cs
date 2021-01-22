    static void Main(string[] args)
    {
        try
        {
            TestMe();
        }
        catch (Exception ex)
        {
            string ss = ex.ToString();
        }
    }
    
    static void TestMe()
    {
        try
        {
            //here's some code that will generate an exception - line #17
        }
        catch (Exception ex)
        {
            //throw new ApplicationException(ex.ToString());
            throw ex; // line# 22
        }
    }
