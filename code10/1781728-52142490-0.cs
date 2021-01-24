     public void Test()
        {
            IList<int> myList = new List<int>() { 1, 10, 20 };
            IReadOnlyList<int> myReadOnlyCollection = new ReadOnlyCollection<int>(myList);
            GetElement(myReadOnlyCollection,1);
        }
 
     private int GetElement(IReadOnlyList<int> list,int index)
        {
            return list[index];
        }
    //Output: 10
