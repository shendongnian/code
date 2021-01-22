    ListControl lstMyControl=null; //You would think C# would assume everything starts as null anyway
    
        switch (SomeVariable)
        {
           case SomeEnum.Value1:
           lstMyControl = new DropDownList();
           break;
           case default:
           lstMyControl = new RadioButtonList;
           break;
        }
    
    lstMyControl.CssClass = "SomeClass";
