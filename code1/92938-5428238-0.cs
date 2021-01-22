    class MyObject{
      private MyEnum myEnumProperty;
      public MyEnum MyEnumProperty{get {return myEnumProperty;}}
    }
    MyObject myObj = new MyObject();
    myCombo.DataBindings.Add(new Binding("SelectedIndex", myObject, "MyEnumProperty");
