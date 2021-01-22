    class MainClass {
      class A { Whatever }
      class B {
        List<A> SubSetList;
        public void AddNewItem(A newItem, Func<A, bool> checkForItemInMasterList)
        {
            if (checkForItemInMasterList.Invoke(newItem)
                SubList.Add(newItem);
        }
      }
      //I don't know how you're adding items to instances of B.
      //This is purely speculative.
      public void AddItem(A newItem)
      {
          new B().AddNewItem(newItem, x => MasterList.Contains(x));
      }
      List<A> MasterList;
    }
