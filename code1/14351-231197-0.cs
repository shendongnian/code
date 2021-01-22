    public class MyTypeComparer : IComparer<MyType>
    {
      public MyTypeComparer() // default comparer on ID
      { ... }
      public MyTypeComparer(bool desc) // default with order specified
      public MyTypeComparer(string sort, bool desc) // specified sort and order such as property name, true or false.
      { ... }
      public int Compare(MyType a, MyType b) // implement IComparer interface
      { ... } // this is real sorting codes
    }
