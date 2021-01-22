    public void Linq52() {
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };
        
        IEnumerable<int> aOnlyNumbers = numbersA.Except(numbersB);
        
        Console.WriteLine("Numbers in first array but not second array:");
        foreach (var n in aOnlyNumbers) {
            Console.WriteLine(n);
        }
    }
