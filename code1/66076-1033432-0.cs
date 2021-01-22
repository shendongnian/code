            mVar4 = new DataTable();
            // Create DataColumn objects of data types.
            DataColumn colString3 = new DataColumn("StringCol1234");
            colString2.DataType = System.Type.GetType("System.String");
            mVar4.Columns.Add(colString3);
            foreach (DataColumn tCol in mVar3.Columns)
            {
                Console.WriteLine(tCol.ColumnName); // still outputs test
            }
            foreach (DataColumn tCol in mVar4.Columns)
            {
                Console.WriteLine(tCol.ColumnName); // now outputs StringCol1234
            }
