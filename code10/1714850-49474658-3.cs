    int i = 0;
    
    foreach(char c in expression)
    {
        if (c == '+')
        {
             Console.WriteLine("plus detected! :{0}", i);
        }
        i++;
    }
