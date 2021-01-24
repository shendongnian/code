    for(int i=0; i < _farmAnimals.Count; i++)
    {
          var species = _farmAnimals[i].Species(); // get species of current item
          _farmAnimals.RemoveAt(i); // remove from list
          Console.WriteLine(species); // display it
    }
