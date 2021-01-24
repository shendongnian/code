            //We add the columns it must be similair to our User class
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Id", //You can set here the title of column
                DisplayMemberBinding = new Binding("ID") //The Biding value must be matched to our User Class proprety ID
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")//The Biding value must be matched to our User Class proprety Name
            });
            FillUsersListView(); //We call here the method in order to fill our listview with data!
