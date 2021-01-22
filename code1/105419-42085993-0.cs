    public void ExportFullDetails()
        {
            Int16 id = Convert.ToInt16(Session["id"]);
            DataTable registeredpeople = new DataTable();
            registeredpeople = this.dataAccess.ExportDetails(eventid);
            string attachment = "attachment; filename=Details.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            string tab = "";
            
            registeredpeople.Columns["Reg_id"].ColumnName = "Reg. ID";
            registeredpeople.Columns["Name"].ColumnName = "Name";
            registeredpeople.Columns["Reg_country"].ColumnName = "Country";
            registeredpeople.Columns["Reg_city"].ColumnName = "City";
            registeredpeople.Columns["Reg_email"].ColumnName = "Email";
            registeredpeople.Columns["Reg_business_phone"].ColumnName = "Business Phone";
            registeredpeople.Columns["Reg_mobile"].ColumnName = "Mobile";
            registeredpeople.Columns["PositionRole"].ColumnName = "Position";
            registeredpeople.Columns["Reg_work_type"].ColumnName = "Work Type";
            foreach (DataColumn dc in registeredpeople.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int i;
            foreach (DataRow dr in registeredpeople.Rows)
            {
                tab = "";
                for (i = 0; i < registeredpeople.Columns.Count; i++)
                {
                    Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }
