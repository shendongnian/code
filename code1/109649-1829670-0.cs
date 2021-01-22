    MyControl my_ctrl = list[0] as MyControl;
    if(my_ctrl != null)
    {
      my_ctrl.SomeFunction();
    }
    // Or
    if(list[0] is MyControl)
    {
      ((MyControl)list[0]).SomeFunction();
    }
