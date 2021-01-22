    internal CreateModel()
    {
        Model d = new Model();
        
        // Invoke the action on the dispatcher of the DataGrid
        MainDataGrid.Dispatcher.Invoke( DispatcherPriority.Normal, 
                           new Action<Model>(
                              delegate(Model d1)
                              {
                                  mModel = d1;   // mModel is a property defined in Window
                                  Binding b = new Binding();
                                  b.Source = mModel; 
                                  MainDataGrid.SetBinding(TreeView.ItemsSourceProperty, mainb);
                              }            
    }
