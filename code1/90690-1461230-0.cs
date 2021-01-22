    public static string MasterMethod(int param, Func<int,string> function)
    {
        return function(param);
    }
    // Call via:
    string result = MasterMethod(2, a => 
    {
        if(a == 1)
        {
           return "if";
        }
        else
        {
           return "else";
        }
     });
