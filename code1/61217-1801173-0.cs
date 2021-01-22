    DataSet ds = dataLayer.GetSomeData(1, 2, 3);
    if(ds != null){
        if(ds.Tables.Count > 0){
            DataTable dt = ds.Tables[0];
            foreach(DataRow dr in dt.Rows){
                //Do some processing
            }
        }
    }
