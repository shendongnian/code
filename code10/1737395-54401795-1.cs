    try   
    {
       vriendenkringDataSetTableAdapters.FriendsTableTableAdapter FTTA = new vriendenkringDataSetTableAdapters.FriendsTableTableAdapter();
      
       // This is the new "Data Table" we're creating. 
       vriendenkringData.FriendsTableDataTable FTDT = new  vriendenkringData.FriendsTableDataTable(); 
       
       // We're now telling our Adapter to connect, get the data, and put it in our Data Table (Named FTDT above). 
       FTTA.Fill(FTDT); 
       MessageBox.Show(FTDT.Count()); //Note - Message box know's to convert the number to a string without you calling "Count.ToString()" :) 
       MessageBox.Show("Friend added succefully");
    }
    catch
    {
        MessageBox.Show("Something went wrong");
        // MessageBox.Show(Convert.ToString(RecordCount)); 
    }
