            ADOX.Table table = new ADOX.Table();
            table.Name = "Users";   // Table name
            // Column 1 (id)
            ADOX.ColumnClass idCol = new ADOX.ColumnClass();
            idCol.Name = "Id";  // The name of the column
            idCol.ParentCatalog = catalog;
            idCol.Type = ADOX.DataTypeEnum.adInteger;   // Indicates a four byte signed integer.
            idCol.Properties["AutoIncrement"].Value = true;     // Enable the auto increment property for this column.
            // Column 2 (Name)
            ADOX.ColumnClass nameCol = new ADOX.ColumnClass();
            nameCol.Name = "Name";    // The name of the column
            nameCol.ParentCatalog = catalog;
            nameCol.Type = ADOX.DataTypeEnum.adVarWChar;   // Indicates a string value type.
            nameCol.DefinedSize = 60;   // 60 characters max.
            // Column 3 (Surname)
            ADOX.ColumnClass surnameCol = new ADOX.ColumnClass();
            surnameCol.Name = "Surname";    // The name of the column
            surnameCol.ParentCatalog = catalog;
            surnameCol.Type = ADOX.DataTypeEnum.adVarWChar;   // Indicates a string value type.
            surnameCol.DefinedSize = 60;   // 60 characters max.
            table.Columns.Append(idCol);        // Add the Id column to the table.
            table.Columns.Append(nameCol);      // Add the Name column to the table.
            table.Columns.Append(surnameCol);   // Add the Surname column to the table.
            catalog.Tables.Append(table);   // Add the table to our database.             
            // Close the connection to the database after we are done creating it and adding the table to it.
            ADODB.Connection con = (ADODB.Connection)catalog.ActiveConnection;
            if (con != null && con.State != 0)
                con.Close();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "DataBase\\t.mdb";
            Response.ContentType = "application/x-msaccess";
            Response.AddHeader("Content-Disposition",string.Format("attachment; filename={0}", fileName));
            Response.TransmitFile(fileName);
            Response.End();
