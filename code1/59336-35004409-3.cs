    private static readonly char[] BaseChars = 
             "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
    private static readonly Dictionary<char, int> CharValues = BaseChars
               .Select((c,i)=>new {Char=c, Index=i})
               .ToDictionary(c=>c.Char,c=>c.Index);
    public static string LongToBase(long value)
    {
       long targetBase = BaseChars.Length;
       // Determine exact number of characters to use.
       char[] buffer = new char[Math.Max( 
                  (int) Math.Ceiling(Math.Log(value + 1, targetBase)), 1)];
       var i = (long) buffer.Length;
       do
       {
           buffer[--i] = BaseChars[value % targetBase];
           value = value / targetBase;
       }
       while (value > 0);
       return new string(buffer, (int) i, buffer.Length - (int)i);
    }
    
    public static long BaseToLong(string number) 
    { 
    	char[] chrs = number.ToCharArray(); 
    	int m = chrs.Length - 1; 
    	int n = BaseChars.Length, x;
    	long result = 0; 
    	for (int i = 0; i < chrs.Length; i++)
    	{
    		x = CharValues[ chrs[i] ];
    		result += x * (long)Math.Pow(n, m--);
    	}
    	return result; 	
    } 
