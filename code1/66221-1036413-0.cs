     DataTable dt=new DataTable();
        DataTable dt1 = new DataTable();
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        ds.Tables.Add(dt1);
        ds.Relations.Add("children", dt.Columns["GSICCodeID"], dt1.Columns["GSICCodeID"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            tvSicCode.Nodes.Clear();
            Int32 i = 0;
            foreach (DataRow masterRow in ds.Tables[0].Rows)
            {
                TreeNode masterNode = new TreeNode((string)masterRow["Description"], Convert.ToString(masterRow["GSicCodeID"]));
                tvSicCode.Nodes.Add(masterNode);
                foreach (DataRow childRow in masterRow.GetChildRows("Children"))
                {
                    TreeNode childNode = new TreeNode((string)childRow["SICCodeDesc"], Convert.ToString(childRow["SICCodeID"]));
                    if (Convert.ToString(ds.Tables[1].Rows[i]["CarrierSICCode"]) != "")
                        childNode.Checked = true;
                    masterNode.ChildNodes.Add(childNode);
                    i++;
                }
            }
            tvSicCode.CollapseAll();
        }
