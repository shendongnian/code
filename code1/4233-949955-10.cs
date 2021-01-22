    public static void FastForEach<T>(this IList<T> collection, Action<T> actionToPerform)
        {
            int count = collection.Count();
            for (int i = 0; i < count; ++i)
            {
                actionToPerform(collection[i]);    
            }
            Console.WriteLine();
        }
