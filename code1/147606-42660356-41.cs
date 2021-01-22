    public static void PrintLifeForms(IEnumerable<LifeForm> lifeForms)
    {
        foreach (var lifeForm in lifeForms)
        {
            Console.WriteLine(lifeForm.GetType().ToString());
        }
    }
