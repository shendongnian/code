    public IEnumerable<MyObject> GetMyObjects(params FilterObject[] filters)
    {
       var myArray = new AnotherType[filters.Length];
       for (int i = 0; i < myArray.Length; i++) 
       {
          myArray[i] = filters[i].ConvertToAnotherType();
       }
       return service.GetMyObjects(myArray);
    }
