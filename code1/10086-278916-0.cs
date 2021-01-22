    DataSet ds = GeneratePickingNoteDataSet(id);
    foreach (DataRow row in ds.Tables[0].Rows) {
        CPickingNoteData pickingNoteData = new CPickingNoteData();
    
        pickingNoteData.delivery_date = (DateTime)row["delivery_date"];
        pickingNoteData.cust_po = (int)row["CustomerPONumber"];
        pickingNoteData.address = row["CustomerAddress"].ToString();
        // ... and so on ...
    
        rptData.Add(pickingNoteData);
    }
