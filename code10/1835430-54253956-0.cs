    public static void PrintCatalog<T>(Dictionary<string, T> catalog) where T : ArticleItemBase
    {
        foreach (var item in catalog)
        {
            Console.WriteLine(item.Value.ToString());
        }
    }
