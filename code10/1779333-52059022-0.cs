            GridView grid = new GridView();
            grid.Columns.Add(new GridViewColumn { Header = "Id", DisplayMemberBinding = new Binding("Id") });
            grid.Columns.Add(new GridViewColumn { Header = "File", DisplayMemberBinding = new Binding("FileName") });
            grid.Columns.Add(new GridViewColumn { Header = "Status", DisplayMemberBinding = new Binding("Status") });
            FilesList.View = grid;
            ListViewItem viewItem = new ListViewItem();
            viewItem.Content = new MyItem { Id = 1, FileName = "test", Status = SignStatus.NotSigned };
            FilesList.Items.Add(viewItem);
