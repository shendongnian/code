        private void Form1_Load(object sender, EventArgs e)
        {
            ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.CheckBoxes = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;
            var dsUsers = GetUserNamesList();
            int rowsCount = dsUsers.Count;
            ListViewItem lvi = new ListViewItem("item1", 0);
            for (int i = 0; i < rowsCount; i++)
            {
                var dRow = dsUsers[i].Name;
                lvi = new ListViewItem("item" + i, i);
                lvi.SubItems.Add(dsUsers[i].UserId.ToString().Trim());
                lvi.SubItems.Add(dsUsers[i].Name.ToString().Trim());
                lvi.SubItems.Add(dsUsers[i].LastName.ToString().Trim());
                listView1.Items.AddRange(new ListViewItem[] { lvi });
            }
            
            listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);
          
            ImageList imageListSmall = new ImageList();
            ImageList imageListLarge = new ImageList();
          
            listView1.LargeImageList = imageListLarge;
            listView1.SmallImageList = imageListSmall;
            this.Controls.Add(listView1);
        }
        public IList<ClientModel> GetUserNamesList()
        {
            ClientModel user = null;
            IList<ClientModel> listusers = new List<ClientModel>();
            user = new ClientModel();
            user.UserId = 1;
            user.Name = "Juan 1";
            user.LastName = "Donoban 1";
            listusers.Add(user);
            //////////////////////////////////////
            user = new ClientModel();
            user.UserId = 2;
            user.Name = "Juan 2";
            user.LastName = "Donoban 2";
            listusers.Add(user);
            return listusers;
        }
    }
