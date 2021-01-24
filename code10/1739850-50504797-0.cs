    Label lbl = new Label();
    lbl.SetBinding(Label.TextProperty, modelProperty.Name, BindingMode.TwoWay);
    TapGestureRecognizer tgr= new TapGestureRecognizer
    {
      Command = BindingContext.CellClickedCommand,
    };
    tgr.SetBinding(TapGestureRecognizer.CommandParameterProperty, ".");
    lbl.GestureRecognizers.Add(tgr);
