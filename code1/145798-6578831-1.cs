    TreeNode node;
    node = new TreeNode(Session["Type"].ToString(), Session["Type"].ToString(), "", "Sub_cat.aspx?MainCat=" + Session["Type"].ToString(), "");
    node.SelectAction = TreeNodeSelectAction.SelectExpand;
    TreeView1.Nodes.Add(node);
    string str1 = "select * from sub_cat where main_cat='"+Session["Type"].ToString() +"'"; ///+ node.Text + "'";
    dt1 = db.gettable(str1);
    for(int x=0;x<dt1.Rows.Count;x++)
    {
        //Session["subcat"] = dt1.Rows[x]["sub_cat"].ToString();
        string sub = dt1.Rows[x]["sub_cat"].ToString();
        TreeNode node1 = new TreeNode(dt1.Rows[x]["sub_cat"].ToString(), dt1.Rows[x]["sub_cat"].ToString(), "", "Product_collection.aspx?sub_cat=" + sub, "");
        node1.SelectAction = TreeNodeSelectAction.SelectExpand;
        //TreeView1.Nodes.Add(node1);
        node.ChildNodes.Add(node1);
    
        string str2 = "select * from product_master where main_cat='" + Session["Type"].ToString() + "' and sub_cat='" + node1.Text + "' order by product_code asc";
        dt2 = db.gettable(str2);
        for(int y=0;y<dt2.Rows.Count;y++)
        {
           // Session["product_code"]=dt2.Rows[y]["product_code"].ToString();
            string code = dt2.Rows[y]["product_code"].ToString();
            TreeNode node2 = new TreeNode(dt2.Rows[y]["product_code"].ToString(), dt2.Rows[y]["product_code"].ToString(), "", "prod_desc.aspx?product_code=" + code, "");
            node2.SelectAction= TreeNodeSelectAction.SelectExpand;
            node1.ChildNodes.Add(node2);
        }
    }
