    //Next with looping    
    public static Enum Next(this Enum input)
    {
        Array Arr = Enum.GetValues(input.GetType());
        int j = Array.IndexOf(Arr, input) + 1;
        return (Arr.Length == j) ? (Enum)Arr.GetValue(0) : (Enum)Arr.GetValue(j);
    }
    
    //Previous with looping
    public static Enum Prev(this Enum input)
    {
       Array Arr = Enum.GetValues(input.GetType());
       int j = Array.IndexOf(Arr, input) - 1;
       return (j == -1) ? (Enum)Arr.GetValue(Arr.Length -1) : (Enum)Arr.GetValue(j);
    }
