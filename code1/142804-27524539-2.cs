    foreach (DataGridViewColumn column in GrdMarkBook.Columns)  
                          //GrdMarkBook is Data Grid name
    {                      
        string HeaderName = column.HeaderText.ToString();
        //  This line Used for find any Column Have Name With Exam
        if (column.HeaderText.ToString().ToUpper().Contains("EXAM"))
        {
            int CoumnNo = column.Index;
        }
    }
