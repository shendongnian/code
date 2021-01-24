    //you could even use byte for this to save memory :)
    int index = -1;
    Console.WriteLine("enter");
    string expression = Console.ReadLine();
    foreach (char c in expression)
        if (c == '+')
            Console.WriteLine("plus detected! :{0}", (index = expression.IndexOf(c,index + 1)));
    Console.ReadLine();
