    private List<DropDownList> CreateDropDownLists()
            {
                List<DropDownList> listDDL = new List<DropDownList>();
                for (int counter = 0; counter < NumberOfControls; counter++)
                {
                    DropDownList ddl = new DropDownList();
    
                    SqlDataReader dr2 = ADONET_methods.DisplayTableColumns(targettable);
                    ddl.ID = "DropDownListID" + (counter + 1).ToString();
    
                    int NumControls = targettable.Length;
                    DataTable dt = new DataTable();
                    dt.Load(dr2);
    
                    ddl.DataValueField = "COLUMN_NAME";
                    ddl.DataTextField = "COLUMN_NAME";
                    ddl.DataSource = dt;
                    ddl.ID = "DropDownListID 1";
                    ddl.SelectedIndexChanged += new EventHandler(ddlList_SelectedIndexChanged);
                    ddl.DataBind();
    
                    ddl.AutoPostBack = true;
                    ddl.EnableViewState = true; //Preserves View State info on Postbacks
                    //ddlList.Style["position"] = "absolute";
                    //ddl.Style["top"] = 80 + "px";
                    //ddl.Style["left"] = 0 + "px";
                    dr2.Close();
    
                    listDDL.Add(ddl);
                }
                return listDDL;
            }
