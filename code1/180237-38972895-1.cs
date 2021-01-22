    //   The types you want to select
    var typeToBeSelected = new List<Type>
    {
        typeof(TextBox)
        , typeof(MaskedTextBox)
        , typeof(Button)
    };
    //    Only one call
    var allControls = MyControlThatContainsOtherControls.GetAll(typeToBeSelected);
    
    //    Do something with it
    foreach(var ctrl in allControls)
    {
        ctrl.Enabled = true;
    }
