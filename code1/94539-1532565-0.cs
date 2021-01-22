    // ...
    
    int i = 0;
    foreach (MyServiceConfigElement service in obj.Services)
                CreateServiceControl(service, i++);
    
    // ...
    
    private void CreateServiceControl(MyServiceConfigElement service, int i)
    {
            TabPage tp = new TabPage(service.Name);
                    tabControl1.TabPages.Insert(i, tp);
    // ...
    
    }
