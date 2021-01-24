    DataContext = this;
    receptenDg.BeginInit();
    db.CreateTable();
    receptenDg.SetBinding(ItemsControl.ItemsSourceProperty, new Binding
    {
    Source = db.dt.Tables[0]
                    
    });
    receptenDg.AutoGenerateColumns = true;
    receptenDg.CanUserAddRows = false;
    db.dt.Tables[0].RowChanged += new DataRowChangeEventHandler(Row_Changed);
    db.dt.Tables[0].RowDeleted += new DataRowChangeEventHandler(Row_Deleted);
    receptenDg.Items.Refresh();
    receptenDg.EndInit();
