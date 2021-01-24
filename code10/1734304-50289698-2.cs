    foreach (TransactionTP b in matrix)
    {
        int itemCount = 0;
        //remember to null check to be defensive
        if (b.itemsUtilities != null)
        {
            itemCount = b.itemsUtilities.Sum(s => s.item);
        }
        //presuming this is an console app?
        Console.Write(itemCount);
    }
