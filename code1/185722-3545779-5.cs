    List<MyClass> items = new List<MyClass>();
    for (int i = 0; i < items.Count; i++)
    {
        if (/* condition */)
        {
            items.RemoveAt(i);
            i--;
        }
    }
