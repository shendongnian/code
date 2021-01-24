    [WebMethod(EnableSession = true)]
    
        public static DataForClientSide[] GetObject(int Value)
        {
    List<DataForClientSide> details = new List<DataForClientSide>();
            LogicTableAdapters.getValuesTableAdapter getObj = new LogicTableAdapters.getValuesTableAdapter();
    
            DataTable getObj = getObj.getValuesTableAdapter(Value);
            DataTable dtObj = new DataTable();
            dtObj.Columns.AddRange(new DataColumn[4]{ new DataColumn("ObjectID", typeof(string)), new DataColumn("ObjectName", typeof(string)), new DataColumn("ObjectValue", typeof(string)), new DataColumn("ParentID", typeof(int)),       
    
                        });
    
            foreach (DataRow dr in getObj.Rows)
            {
                            DataForClientSide Info= new DataForClientSide();
                            Info.id = dr["ObjectID"].ToString();
                            Info.name = dr["ObjectName"].ToString();
                            Info.value = dr["ObjectValue"].ToString();
                            //multiple data as u want. . . . . 
                            details.Add(Info);
    
            }
            return details.ToArray();
        }
