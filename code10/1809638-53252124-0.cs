    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Empty");
            return;
        }
        for (int i = 0; i <= top; i++)
        {
            Console.WriteLine(dataStack[i]);
        }
    }
