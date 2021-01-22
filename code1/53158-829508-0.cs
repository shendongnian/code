    public static IEnumerable Digits()
    {
        return new[]{1, 15, 68, 1235, 12390, 1239};
    }
    var enumerable = Digits().OfType<int>();
    foreach (var item in enumerable)
        // var is here an int. Without the OfType<int(), it would be an object
        Console.WriteLine(i);
