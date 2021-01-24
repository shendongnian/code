    public static void Main()
    {
        IEnumerable<int> number = GetNumbers();
        IEnumerable<int> smallNumbers = numbers.Where(number => number < 3);
        IEnumerator<int> smallEnumerator = smallNumbers.GetEnumerator();
        bool smallNumberAvailable = smallEnumerator.MoveNext();
        while (smallNumberAvailable)
        {
            int smallNumber = smallEnumerator.Current;
            Console.WriteLine(smallNumber);
            smallNumberAvailable = smallEnumerator.MoveNext();
        }
    }
