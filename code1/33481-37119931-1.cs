    private void FillAddresses()
        {
            // erase any old data
            if (AddrTable != null)
                AddrTable.Clear();
            else
                AddrTable = new DataTable();
            // switch-case for panel types that need an address
            switch(PanelType)
            {
                case "Customer":
                case "Customers":
                case "Location":
                case "Locations":
                case "Employee":
                case "Employees":
                    BuildStateColumnChoices();
                    SqlCommand sqlAddrCmd = new SqlCommand();
                    sqlAddrCmd.CommandText = "exec SecSchema.sp_GetAddress " + PanelType +
                        "," + ObjectID.ToString(); // Fill the DataTable with a stored procedure
                    sqlAddrCmd.Connection = DBConnection;
                    sqlAddrCmd.CommandType = CommandType.Text;
                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlAddrCmd);
                    try
                    {
                        sqlDA.Fill(AddrTable);
                        dgvAddresses.AutoGenerateColumns = false;
                        // Actually, you set both the DataSource and DataPropertyName properties to bind the data
                        dgvAddresses.DataSource = AddrTable;
                        
                        // Note that the column parameters are using the name of the object from the designer.
                        // This differs from the column names.
                        // The DataProperty name is set to the column name returned from the Stored Procedure
                        dgvAddresses.Columns["colAddrType"].DataPropertyName = "Type";
                        dgvAddresses.Columns["collAddress"].DataPropertyName = "Address";
                        dgvAddresses.Columns["colAptNum"].DataPropertyName = "Apt#";
                        dgvAddresses.Columns["colCity"].DataPropertyName = "city";
                        dgvAddresses.Columns["colState"].DataPropertyName = "State";
                        dgvAddresses.Columns["colZIP"].DataPropertyName = "ZIP Code";
                    }
                    catch(Exception errUnk)
                    {
                        MessageBox.Show("Failed to load address data for panel type " +
                            PanelType + "..." + errUnk.Message, "Address error",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    
                    break;
            }
        }
