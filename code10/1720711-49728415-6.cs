          //Class to hold data
      public class MyRecordContent
      {
            public MyRecordContent()
            {
                //initialise list
                RecordsColumns = new List<string>();
            }
            //Holds a list of strings for each column of the record.
            //It starts at position 0 to however many columns you have
            public List<string> RecordsColumns { get; set; }
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
             //Here you build up a list of all records and their field content from your xml.
            foreach (var xmlNode in yourXMLRecordCollection)
            {
                var thisRecord = new MyRecordContent();
                foreach (var xmlCol in xmlNode.Elements)//Each column value
                {
                    thisRecord.RecordsColumns.Add(xmlCol.GetValue());
                }
                
                myListOfRecords.Add(thisRecord);
            }
            foreach (MyRecordContent record in myListOfRecords)
            {
                var row = myTable.NewRow();
                //Here we set each row column values in the datatable.
                //Map each rows column value to be the value in the list at same position.
                for (var colPosition = 0; colPosition <= myTable.Columns.Count - 1;) //Number of columns added.
                {
                    row[colPosition] = record.RecordsColumns[colPosition];
                }
                myTable.Rows.Add(row);
            }
  
