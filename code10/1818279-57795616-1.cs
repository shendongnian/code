    myDataTable.AcceptChanges(); //Trick that allows us to delete during a ForEach!
    foreach (DataRow myDataRow in myDataTable.Rows)
    {
       //Grab the Key Values
       string strKey1Value = Convert.ToString(myDataRow ["Col1"]);
       string strKey2Value = Convert.ToString(myDataRow ["Col2"]);
       if (myQuickLookUpCount.TryGetValue(strKey1Value + strKey2Value, out Int32 intTotalCount) == true && intTotalCount > 0)
       {
         myDataTable.Delete();  //Mark our Row to Delete
         myQuickLookUpCount [strKey1Value + strKey2Value ] -= 1;  //Decrement our Counter
        }
     }
                
     myDataTable.AcceptChanges(); //Commits our changes and actually deletes the rows.
