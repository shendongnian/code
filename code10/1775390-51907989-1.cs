    for(int i=_farmAnimals.Count -1; i >= 0; i--)
    {
          var species = _farmAnimals[i].Species(); // get species of current item
          _farmAnimals.RemoveAt(i); // remove from list
          Console.WriteLine(species); // display it
    }
