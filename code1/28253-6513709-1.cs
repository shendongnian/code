    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
            {
                
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        // Bind drop down to PrerequisiteCourseCodes
                        DropDownList ddl = (DropDownList)e.Row.FindControl("ddlPrerequisiteCourseCode");
                        ddl.DataSource = PrerequisiteCourseCodeList;
                        ddl.DataBind();
                    }
                
            }
