    public static string Wordify(this Enum input)
    {            
        Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
        return r.Replace( input.ToString() , " ${x}");
    }
    //then your calling syntax is down to:
    MyEnum.ThisIsA.Wordify();
