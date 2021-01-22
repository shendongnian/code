    int currentCustomerID = 134;
    var listViewItems = customers.Select(c => {
                            ListViewItem i = new ListViewItem();
                            i.Name = c.Name;
                            i.Value = c.CustomerID;
                            i.IsSelected = c.CustomerID == currentCustomerID;
                            i.Tag = c;
                            return i;
                        });
