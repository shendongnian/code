    public static DataTable JoinDataTables2(DataTable dt1, DataTable dt2, string table1KeyField, string table2KeyField) {
       DataTable result = ( from dataRows1 in dt1.AsEnumerable()
                                join dataRows2 in dt2.AsEnumerable()
                                on dataRows1.Field<string>(table1KeyField) equals dataRows2.Field<string>(table2KeyField) 
                                select new {Col1= datarows1Field<string>(table1FieldName), Col2= datarows2.Field<string>(table2FieldName)}).Distinct().CopyToDataTable();
       return result;
    }
