    // using static System.Linq.Expressions.Expression
    public static Dictionary<string, (int code, int? min, int? max)> Items = new Dictionary<string, (int code, int? min, int? max)>(){
        { "Modern (Less than 10 years old)", (1, null, 10) },
        { "Retro (10 - 20 years old)", (2, 10, 20) },
        { "Vintage(20 - 70 years old)", (3, 20, 70) },
        { "Antique(70+ years old)", (4, 70, null) }
    };
