    public static class ListExtensionMethods
    {
        ...
        static public void AddSomething<T>(this List<T> list, string line, int trace = 0)
        {
            //do some processing on line
            //then
            list.Add(line);
        }
        static public void Finish<T>(this List<T> list)
        {
            ...
        }
        ...
    }
