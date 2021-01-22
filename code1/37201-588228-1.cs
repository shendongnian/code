    var s = new SplitBoxSetup();
    s.AddVerticalSplit()
     .PanelOne().PlaceControl(()=> new Label())
     .PanelTwo()
     .AddHorizontalSplit()
     .PanelOne().PlaceControl(()=> new Label())
     .PanelTwo().PlaceControl(()=> new Panel());
    form.Controls.Add(s.TopControl);
