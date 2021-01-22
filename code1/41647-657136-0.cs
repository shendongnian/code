    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+filename+";Extended Properties=Excel 8.0");
    con.Open();
    try
    {
         //Create Dataset and fill with imformation from the Excel Spreadsheet for easier reference
         DataSet myDataSet = new DataSet();
         OleDbDataAdapter myCommand = new OleDbDataAdapter(" SELECT * FROM ["+listname+"$]" , con);
         myCommand.Fill(myDataSet);
         con.Close();
         richTextBox1.AppendText("\nDataSet Filled");
         //Travers through each row in the dataset
         foreach (DataRow myDataRow in myDataSet.Tables[0].Rows)
         {
              //Stores info in Datarow into an array
              Object[] cells = myDataRow.ItemArray;
              //Traverse through each array and put into object cellContent as type Object
              //Using Object as for some reason the Dataset reads some blank value which
              //causes a hissy fit when trying to read. By using object I can convert to
              //String at a later point.
              foreach (object cellContent in cells)
              {
                   //Convert object cellContect into String to read whilst replacing Line Breaks with a defined character
                   string cellText = cellContent.ToString();
                   cellText = cellText.Replace("\n", "|");
                   //Read the string and put into Array of characters chars
                   richTextBox1.AppendText("\n"+cellText);
              }
         }
         //Thread.Sleep(15000);
    }
    catch (Exception ex)
    {
         MessageBox.Show(ex.ToString());
         //Thread.Sleep(15000);
    }
    finally
    {
         con.Close();
    }
