    DataGridTextColumn product = new DataGridTextColumn();
                    product.Binding = new System.Windows.Data.Binding("Product");
                    product.Header = "Product";
    
                    DataGridTextColumn date = new DataGridTextColumn();
                    date.Binding = new System.Windows.Data.Binding("Date");
                    date.Header = "Date";
    
                    DataGridTextColumn version = new DataGridTextColumn();
                    version.Binding = new System.Windows.Data.Binding("FileVersion");
                    version.Header = "Version";
    
                    DataGridTextColumn timestamp = new DataGridTextColumn();
                    timestamp.Header = "TimeStamp";
                    timestamp.Binding = new System.Windows.Data.Binding("TimeStamp");
    
                    DataGridTextColumn user = new DataGridTextColumn();
                    user.Header = "User";
                    user.Binding = new System.Windows.Data.Binding("User");
    
                    rpdata.Columns.Add(product);
                    rpdata.Columns.Add(date);
                    rpdata.Columns.Add(version);
                    rpdata.Columns.Add(timestamp);
                    rpdata.Columns.Add(user);
