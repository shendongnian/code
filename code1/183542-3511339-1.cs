    class MyClass
    {
      [Editor(typeof(MyCollectionEditor), 
              typeof(System.Drawing.Design.UITypeEditor))]
      List<Foo> MyCollection
      {
        get; set;
      }
    }
