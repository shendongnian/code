    static void Main(string[] args) 
    {
       String a = "Hello "; 
       String b = " World! ";
    
       int it = 20000;
       char[] result = new char[a.Length + it*b.Length];
       a.ToCharArray().CopyTo(result, 0);
    
       for (int i = 0; i < it; i++) 
          b.ToCharArray().CopyTo(result, a.Length + i * b.Length);
    
       Console.WriteLine(result);    
    }
