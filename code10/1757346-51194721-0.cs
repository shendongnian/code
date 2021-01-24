    static string ConcatMultilineString(string a, string b)
    {
    	string splitOn = "\r\n|\r|\n";
    	string[] p = Regex.Split(a, splitOn);
    	string[] q = Regex.Split(b, splitOn);
    
    	return string.Join("\r\n", p.Zip(q, (u, v) => u + v));
    }
    
    static void Main(string[] args)
    {
    	string A = "Hello_\rHello_\r\nHello_";
    	string B = "World\r\nWorld\nWorld";
    
    	Console.WriteLine(ConcatMultilineString(A, B));
    
    	Console.ReadLine();
    
    }
