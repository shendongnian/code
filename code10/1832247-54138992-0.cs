    public static void MyAwesomeChangingMethod(int i)
    {
        Console.WriteLine(i);
    }
    
    ...
    
    // now you can call it many times with a different number
    MyAwesomeChangingMethod(1);
    MyAwesomeChangingMethod(3);
    MyAwesomeChangingMethod(675675);
    
    // or
    
    for (int i = 0; i < 5; i++)
        MyAwesomeChangingMethod(i);
