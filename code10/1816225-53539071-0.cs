    private List<InloggenBO> ToList(DataSet dataSet)
    {
        //new list of InloggenBO instead of objects
        var list = new List<InloggenBO>();
        foreach (var dataRow in dataSet.Tables[0].Rows)
        {
            //create a new instance of InloggenBO
            var item = new InloggenBO();
            //this assumes that the column is named as the member
            item.CommissieGroep = dataRow["CommissieGroep"].ToString(); 
            //fill the other members
            //add the instane of InloggenBO to the list
            list.Add(item);
        }
        return list;
    }
