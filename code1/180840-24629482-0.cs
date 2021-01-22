    public static void ExAnonymousType()
    {
        var nguoi = new { Ten = "Vinh", Tuoi = 20 };
        Console.WriteLine(nguoi.Ten + " " + nguoi.Tuoi);
        DoSomeThing(nguoi);
    
    }
    
    private static void DoSomeThing(object nguoi)
    {
        Console.WriteLine(nguoi.GetType().GetProperty("Ten").GetValue(nguoi,null));
    }
