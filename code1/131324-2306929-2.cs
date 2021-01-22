    <%= Html.EnumDropdown("MyProperty", MyEnum.AValue /* selected value */ ) %>
    <%= Html.EnumDropdown(
            "MyProperty", 
            new MyEnum[] { MyEnum.AValue, MyEnum.BValue } /* choices */ ) %>
    <%= Html.EnumDropdown(
            "MyProperty",
            MyEnum.AValue                                 /* selected value */,
            new MyEnum[] { MyEnum.AValue, MyEnum.BValue } /* choices        */ ) %>
