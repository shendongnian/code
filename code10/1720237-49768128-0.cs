    Getting this error because HasChar.Add() return bool. It return true if element added else false. So only getting this error, So use List instead of HashSet.
    Can rewrite following
    
    
    public class Program
        {
            public static void Main(string[] args)
            {
                string str = "faffaa";
                char[] ArrChar = str.ToCharArray();
                MatChar(ArrChar);
                Console.Read();
            }
    
            public static void MatChar(char[] input)
            {
                List<char> HasChar = new List<char>();
                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];
                    if (HasChar.Contains(c))
                    {
                        Console.WriteLine("First repeating character: {0}", c);
                        break;
                    }
                    else
                        HasChar.Add(c);
                }
    
            }
    
        }
