    public int[] Arrsort()
    {
        int[] array = new int[100];
        Random rand = new Random(12345);
    
         for (int i = 0; i <100; i++)
         {
            array[i] = rand.Next(100);
         }
        Array.Sort(array);
        return array;
    }
    
    The code was generating this error...
    Error CS0407 'int[] Program.Arrsort()' has the wrong return type
    
    The problem with the function is that it wasn't working with Thread class object. As in when  I was passing it as follows-->
    
    for (int i = 0; i < 5; i++)
    {
        Thread newThread = new Thread(p.Arrsort);
        newThread.Start();
        int[] arrsort1 = p.Arrsort();
        // for (int n=0; n<arrsort.Length; n++)
        Console.WriteLine(arrsort1[n]); //printing the elements
    }
    
    
