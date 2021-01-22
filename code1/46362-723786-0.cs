    bool hasRepeating = false;
    int previous = 0;
    
    int firstDuplicateValue = a
      .Where(i => i != 0)
      .OrderBy(i => i)
      .FirstOrDefault(i => 
      {
        hasRepeating = (i == previous);
        previous = i;
        return hasRepeating;
      });
    
    if (hasRepeating)
    {
      Console.WriteLine(firstDuplicateValue);
    }
