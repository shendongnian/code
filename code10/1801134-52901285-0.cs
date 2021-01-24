    for(int i=0; i<3; i++)
    {
       array[i] = int.Parse(Console.ReadLine());
       if(i > 0)
       {
           if (array[i] == array[i-1])
               Console.WriteLine("repeating inputs")
       }
    }
