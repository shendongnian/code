    void RecursiveMethod(Items items)
    {
        if (items.Children != null)
        {
            foreach (Items i in items.Children)
            {
                RecursiveMethod(i);
            }
        }
        else
        {
            // Do your stuff..
        }
    }
