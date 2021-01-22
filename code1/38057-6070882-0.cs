                                    DataView dvBindAssignedByDropDown = new DataView();
                                    DataTable dtBindAssignedByDropDown = new DataTable();
                                    dvBindAssignedByDropDown = ds.Tables[0].DefaultView;
                                   
                                    string[] strColnames=new string[2];
                                    strColnames[0] = "RedNames";
                                    strColnames[1] = "RedValues";
                                    dtBindAssignedByDropDown = dvBindAssignedByDropDown.ToTable(true, strColnames);
                                    ddlAssignedby.DataTextField = "RedNamesNames";
                                    ddlAssignedby.DataValueField = "RedNames";
                                    ddlAssignedby.DataSource = dtBindAssignedByDropDown;
                                    ddlAssignedby.DataBind();
                                    ddlAssignedby.Items.Insert(0, "Assigned By");
                                    ddlAssignedby.Items[0].Value = "0";
