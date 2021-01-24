    Search s = new Search();
    int num = 0;
    int [] numsarr = new int[10] { 5, 4, 3, 6, 7, 2, 13, 34, 56, 23 };
    int value = 6;
    Console.WriteLine("num is {0}", num);
    
    int outNum = s.LinearSearchEx(value, numsarr)
    if(outNum > 0)
    {
        Console.WriteLine("Found it");
        Console.WriteLine("Out num is {0}", outNum);
    }
    else
    {
        Console.WriteLine("Sorry not found");
        // Note that outnum will always be the array length if the number wasn't found
        Console.WriteLine("Out num is {0}", numsarr.Length);
    
    }
