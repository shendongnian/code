    static void Main(string[] args)
    {
        int n = 1000, m = 9999;
        for (int i = n; i <= m; i++)
        {
           if (CheckIfNoAndPowerPalindromic(i))
           {
               Console.WriteLine(i);
           }
        }
    }
        
    private static bool CheckIfNoAndPowerPalindromic(int number)
    {
       string numberString = number.ToString();
       string numberSquareString = (number * number).ToString();
       return (Enumerable.SequenceEqual(numberString.ToCharArray(), numberString.ToCharArray().Reverse()) && 
               Enumerable.SequenceEqual(numberSquareString.ToCharArray(), numberSquareString.ToCharArray().Reverse()));
    }
    output:-
    1001
    1111 
    2002.
