    foreach(System.DataRow dr in Tabla.Rows)//iterate rows
    {
        foreach(System.DataColumn dc in Tabla.Columns)  //iterate columns per row
        {
            textboxes.text = dr[dc].ToString();  //get object value at row,column
        }
    }
