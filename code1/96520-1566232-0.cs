        DataSet DSToReturn = new DataSet();
        //logic to filter based on the column NAme
        DataTable results = (from d in ((DataSet)_MyDataset).Tables["Records"].AsEnumerable()
                             orderby d.Field<string>("Name") ascending
                             where d["Name"].ToString().Contains(ProjectName)
                             select d).CopyToDataTable();
                DSToReturn.Tables.Add(results);
        return DSToReturn;
    }
