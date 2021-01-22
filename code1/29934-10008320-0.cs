     private void MainTimesheetForm_Load(object sender, EventArgs e)
            {
                ListViewItem newList = new ListViewItem("1");
                newList.SubItems.Add("2");
                newList.SubItems.Add(DateTime.Now.ToLongTimeString());
                newList.SubItems.Add("3");
                newList.SubItems.Add("4");
                newList.SubItems.Add("5");
                newList.SubItems.Add("6");
                listViewTimeSheet.Items.Add(newList);
                
            }
