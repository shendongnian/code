    datatable osdat = Loaddatatable();
    var filteredTable = osdat.AsEnumerable()
         .Where(row => row.Field<String>("Product") != string.Empty).CopyToDataTable();
    postOScomboBox2.DataSource = osdat;
    postOScomboBox2.DisplayMember = "Product";
    postOScomboBox2.ValueMember = "Product";
    postOScomboBox2.SelectedIndex = -1;
