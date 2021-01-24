            // Populate Department GridView
            // get all lines of csv file
            string[] BuildingString = File.ReadAllLines(Server.MapPath("Content/BuildingsCSV.csv"));
            string[] DepartmentString = File.ReadAllLines(Server.MapPath("Content/DepartmentsCSV.csv"));
            // create new datatable
            DataTable BuildingTable = new DataTable();
            DataTable DepartmentTable = new DataTable();
            // Building Table
            // get the column header means first line
            string[] tempbuild = BuildingString[0].Split(',');
            // creates columns of gridview as per the header name
            foreach (string t in tempbuild)
            {
                BuildingTable.Columns.Add(t, typeof(string));
            }
            // now retrive the record from second line and add it to datatable
            for (int i = 1; i < BuildingString.Length; i++)
            {
                string[] t = BuildingString[i].Split(',');
                BuildingTable.Rows.Add(t);
            }
            // Department Table
            // get the column header means first line
            string[] tempdept = DepartmentString[0].Split(',');
            // creates columns of gridview as per the header name
            foreach (string t in tempdept)
            {
                DepartmentTable.Columns.Add(t, typeof(string));
            }
            // now retrive the record from second line and add it to datatable
            for (int i = 1; i < DepartmentString.Length; i++)
            {
                string[] t = DepartmentString[i].Split(',');
                DepartmentTable.Rows.Add(t);
            }
            // assign gridview datasource property by datatable
            BuildingGrid.DataSource = BuildingTable;
            BuildingGrid.DataBind();
            BuildingGrid.Rows[0].Visible = false;
            DepartmentGrid.DataSource = DepartmentTable;
            DepartmentGrid.DataBind();
            DepartmentGrid.Rows[0].Visible = false;
            foreach (DataRow drb in BuildingTable.Rows)
            {
                BuildingDrop.Items.Add(new ListItem(drb[0].ToString(), drb[1].ToString()));
            }
            foreach (DataRow drd in DepartmentTable.Rows)
            {
                DepartmentDrop.Items.Add(new ListItem(drd[0].ToString(), drd[1].ToString()));
            }
