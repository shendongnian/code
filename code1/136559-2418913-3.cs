    Console.Writeline(Left(myString, 4));
    public static string Left(string param, int length)        
    {        
    string result = param.Substring(0, length);             
    return result;        
    } 
