      ListViewItem item1 = new ListViewItem("Steve Martin");
                item1.SubItems.Add("Programming .NET");
                item1.SubItems.Add("39.95");
    
                ListViewItem item2 = new ListViewItem("Irene Suzuki");
                item2.SubItems.Add("VB.NET Core Studies");
                item2.SubItems.Add("69.95");
    
                ListViewItem item3 = new ListViewItem("Ricky Ericsson");
                item3.SubItems.Add("Passing Your .NET Exams");
                item3.SubItems.Add("19.95");
    
                // Add the items to the ListView.
                listView1.Items.AddRange(
                                        new ListViewItem[] {item1, 
                                                    item2, 
                                                    item3}
                                        );
