    public static void MyEach(this IEnumerable<int> enumeration, Action<int> action)
    { 
        foreach (var item in enumeration)
        {
            action(item);
            //yield return item;
        }
    }
    // Now it will execute right away
    nums.Where(x => x == 1).MyEach(x => Console.WriteLine(x));
