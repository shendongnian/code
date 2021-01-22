    foreach (var module in modules)
    {
        var theModule = module;  // local variable
        var btn = new Button();
        btn.SetResourceReference(Control.TemplateProperty, "SideMenuButton");
        btn.Content = theModule.Title;  // *** use local variable
        btn.MouseEnter += (s, e) => { ShowInfo(theModule.Description); };  // *** use local variable
        btn.MouseLeave += (s, e) => { HideInfo(); };
        ModuleButtons.Children.Add(btn);
    }
