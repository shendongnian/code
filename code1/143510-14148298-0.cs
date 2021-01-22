        //In load for example
        if (!IsPostBack)
        {
                DataSet ds = new DataSet();
                ds = getRoles(); //function that gets data collection from db.
                tvRoles.Nodes.Clear();
                BindTree(ds, null); 
                tvRoles.DataBind();
        }       
        private void BindTree(DataSet ds, TreeNode parentNode)
        {
            DataRow[] ChildRows;
            if (parentNode == null)
            {
                string strExpr = "ParentId=0";
                ChildRows = ds.Tables[0].Select(strExpr);                    
            }
            else
            {
                string strExpr = "ParentId=" + parentNode.Value.ToString();
                ChildRows = ds.Tables[0].Select(strExpr); 
            }   
            foreach (DataRow dr in ChildRows)
            {
                TreeNode newNode = new TreeNode(dr["Name"].ToString(), dr["Id"].ToString());
                if (parentNode == null)
                {
                    tvRoles.Nodes.Add(newNode);
                }
                else
                {
                    parentNode.ChildNodes.Add(newNode);
                }
                BindTree(ds, newNode);
            }
        }
