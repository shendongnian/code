    public static List<T> ConvertToGenericList<T>(IList listOfObjects)
    {
        List<T> items = new List<T>();
        for (int i = 0; i < listOfObjects.Count; i++)
        {
            items.Add((T)listOfObjects[i]);
        }
         return items;
    }
