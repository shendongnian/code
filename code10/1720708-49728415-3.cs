          //Class to hold data
          public class MyRecordContent
          {
                public string Field1 { get; set; }
                public string Field2 { get; set; }
          }
            //Here you build up a list of all records and their field content from your xml.
            var myListOfRecords = new List<MyRecordContent>();
            foreach (var xmlNode in yourXMLRecordCollection)
            {
                var thisRecord = new MyRecordContent();
                thisRecord.Field1 = xmlNode.Attribute("Field1");
                thisRecord.Field2 = xmlNode.Attribute("Field2");
                myListOfRecords.Add(thisRecord);
            }
            //This creates an empty table with the columns
            var myTable = new DataTable("Table1");
            foreach (var item in bla)
            {
                if (!myTable.Columns.Contains(item))
                {
                    myTable.Columns.Add(new DataColumn(item, typeof(string)));
                }
            }
            
            //Now add the rows with the data from the table.
            foreach (MyRecordContent record in myListOfRecords)
            {
                var row = myTable.NewRow();
                row["Field1"] = record.Field1;
                row["Field2"] = record.Field2;
                myTable.Rows.Add(row);
            }
  
