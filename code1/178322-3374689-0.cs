    private void window1_Loaded(object sender, RoutedEventArgs e)
    {
     this.SubSystems = new List<SubSystem>();
    
     this.SubSystems.Add(new SubSystem() { Name = "SubSystem 1", IsSelected = false });
     this.SubSystems.Add(new SubSystem() { Name = "SubSystem 2", IsSelected = false });
     this.SubSystems.Add(new SubSystem() { Name = "SubSystem 3", IsSelected = true });
     this.SubSystems.Add(new SubSystem() { Name = "SubSystem 4", IsSelected = false });
     this.SubSystems.Add(new SubSystem() { Name = "SubSystem 5", IsSelected = true });
    
     this.DataContext = this.SubSystems;
    }
