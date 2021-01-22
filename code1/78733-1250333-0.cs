      public static List<MyObject> SortedObjects(IEnumerable<MyObject> myList) {
    	 SortedList<string, MyObject> sortedList = new SortedList<string, MyObject>();
    	 foreach (MyObject object in myList) {
    		sortedList.Add(object.ValueIWantToSort, object);
    	 }
    
    	 return new List<MyObject>(sortedList.Values);
      }
