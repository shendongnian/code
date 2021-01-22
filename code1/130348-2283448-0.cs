    int numberOfElements = 4;   //parameter
    int[] numbers = new[] { 1, 1, 2, 5, 0, 5, 3, 1, 1 };    //numbers
    
    int[] result =
         //cicle each element
        (from n in Enumerable.Range(0, numbers.Length - numberOfElements + 1)
         //keep the (n + numberOfElements) elements
         let myNumbers = from p in Enumerable.Range(n, numberOfElements)
                         select numbers[p]
         //keep the sum (if we got a 0, sum is 0)
         let sum = myNumbers.Contains(0) ? 0 : myNumbers.Sum()
         orderby sum descending     //order by sum
         select myNumbers)          //select the list
            .First().ToArray();     //first is the highest
