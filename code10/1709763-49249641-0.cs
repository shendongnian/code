    var model = GetDataSource();
          ShapeFileLayer layer=new ShapeFileLayer();
          layer.ItemsSource=model;
          SelectedItemButton.Clicked += (sender, e) =>
           {
            layer.SelectedItems.Add(model[0]);
           };
          RemoveItemButton.Clicked += (sender, e) =>
           {
            layer.SelectedItems.Remove(model[0]);
           }; 
