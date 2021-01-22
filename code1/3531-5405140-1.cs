    var destinationList = new List<someObject>();
    foreach (var item in itemList)
    {
      var stringArray = item.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
      
      if (stringArray.Length != 2)
      {
        //use the destinationList Count property to give us the index into the stringArray list
        throw new Exception("Item at row " + (destinationList.Count + 1) + " has a problem.");
      }
      else
      {
        destinationList.Add(new someObject() { Prop1 = stringArray[0], Prop2 = stringArray[1]});
      }
    }
