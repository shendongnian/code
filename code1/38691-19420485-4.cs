    public static List<T> GetEmptyListOfThisType<T>(this T item)
    {
        return new List<T>();
    }
    //so you can call:
    var list = new { Id = 0, Name = "" }.GetEmptyListOfThisType();
