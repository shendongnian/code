     class Program
        {
            static void Main()
            {
                int[] array1 = { 1, 2, 3 };
                int[] array2 = { 1, 2, 3 };
                IStructuralEquatable structuralEquator = array1;
                Console.WriteLine(array1.Equals(array2));                                  // False
                Console.WriteLine(structuralEquator.Equals(array2, EqualityComparer<int>.Default));  // True
    
                // string arrays
                string[] a1 = "a b c d e f g".Split();
                string[] a2 = "A B C D E F G".Split();
                IStructuralEquatable structuralEquator1 = a1;
                bool areEqual = structuralEquator1.Equals(a2, StringComparer.InvariantCultureIgnoreCase);
    
                Console.WriteLine("Arrays of strings are equal:"+  areEqual);
    
                //tuples
                var firstTuple = Tuple.Create(1, "aaaaa");
                var secondTuple = Tuple.Create(1, "AAAAA");
                IStructuralEquatable structuralEquator2 = firstTuple;
                bool areTuplesEqual = structuralEquator2.Equals(secondTuple, StringComparer.InvariantCultureIgnoreCase);
    
                Console.WriteLine("Are tuples equal:" + areTuplesEqual);
                IStructuralComparable sc1 = firstTuple;
                int comparisonResult = sc1.CompareTo(secondTuple, StringComparer.InvariantCultureIgnoreCase);
                Console.WriteLine("Tuples comarison result:" + comparisonResult);//0
            }
        } 
