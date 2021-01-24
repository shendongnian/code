            listView1.Columns.Add("column1");
            listView1.Columns.Add("column2");
            listView1.Columns.Add("column3");
            listView1.Columns.Add("column4");
            string[] lines = new string[] { "value01,value02,value03,value04", "value11,value12,value13,value14" };
            foreach (string line in lines)
            {                   
                listView1.Items.Add(new ListViewItem(line.Split(',')));
            }
