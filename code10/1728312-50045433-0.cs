    try
    {
        SqlDataReader dr = cm.ExecuteReader();
        //create a dict of strings which holds a list of "items"
        var dict = new Dictionary<string, List<string>>();
        while (dr.Read())
        {
            var orderName = (dr["WorkOrderName"].ToString();
            //fill the dictionary
            if (!dict.ContainsKey(orderName))
                dict.Add(orderName, new List<string>());
            
            dict[orderName].Add(dr["ItemNumber"].ToString());
        }
        //this should also be possible with a single linq statement
        //now loop the dictionary and fill the tree
        foreach (var key in dict.Keys)
        {
           //add parent
           TreeNode node = new TreeNode(key);
       
           //add childs
           foreach(var item in dict[key])
           {
               node.Nodes.Add(item);
           }
           //add it to the treeview
           treeView1.Nodes.Add(node);
        }
    }
    
