    double[] chosenArray = double[0];
    switch (arraychoice.Key)
    {
      case ConsoleKey.A:
        chosenArray = dataset.Num128_change;
        break;
      case ConsoleKey.B:
        chosenArray = dataset.Num128_close;
        break;
    
      //add the other cases
      ....
    }
    bubblesort.Bubblesort(chosenArray);
    foreach (double item in chosenArray)
    {
       Console.WriteLine(item);
    }
    
    Console.ReadKey();
    
