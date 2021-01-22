    List<oPage> mylist = GetYourList();
    
    IEnumerable<oPage> results = (IEnumerable<oPage>)myList.FindAll(
       delegate(oPage p)
       {
          return p.Title.Contains("abc");
       }
    );
