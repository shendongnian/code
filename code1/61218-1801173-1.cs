    public static IEnumerable<DataRow> DataRows(this DataSet current){
        if(current != null){
            if(current.Tables.Count > 0){
                DataTable dt = current.Tables[0];
                foreach(DataRow dr in dt.Rows){
                    yield return dr;
                }
            }
        }
    }
