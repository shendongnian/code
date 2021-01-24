    foreach(dynamic thing in listOfThings) {
    try {
        string propertyOne = thing.PropertyOne;
        string propertyTwo = thing.PropertyTwo;
        doWork(propertyOne, propertyTwo);
    }
    catch(RuntimeBinderException ex)
    {
      //log the exception
      continue;
    }
    }
