     using System;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Linq;
    using System.Configuration;
    using System.Data.SqlClient;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT   [Id],[CartridgeSetNo],[status] ,[dateRecieved],[Comments] ,case when status = 1 then 'Received but not usable' when status = 0 then 'Received and Usable' else 'Not Received' end as currentstatus FROM DrugAllocate ");
            gvCustomers.DataSource = this.ExecuteQuery(cmd, "SELECT");
            gvCustomers.DataBind();
        }
        private DataTable ExecuteQuery(SqlCommand cmd, string action)
        {
            string conString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                switch (action)
                {
                    case "SELECT":
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                return dt;
                            }
                        }
                    case "UPDATE":
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        break;
                }
                return null;
            }
        }
    
        protected void Update(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCustomers.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    if (isChecked)
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE DrugReceipt SET Comments=@Comments,  dateRecieved=@dateRecieved , status = @status where Id = @Id");
                        cmd.Parameters.AddWithValue("@Comments", row.Cells[5].Controls.OfType<TextBox>().FirstOrDefault().Text);
                       
                        string status = row.Cells[3].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value;
                        if (status == "Received and Usable")
                        {
                            status="0";
                        }
                        if (status == "Received but not usable")
                        {
                           string comments=row.Cells[5].Controls.OfType<TextBox>().FirstOrDefault().Text;
                            status = "1";
                            if (comments == "")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('comment is mendatry');", true);
                                break;
                            }
                        }
                        if (status == "Not Received")
                        {
                            status = "2";
                        }
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@dateRecieved", row.Cells[4].Controls.OfType<TextBox>().FirstOrDefault().Text);
                        cmd.Parameters.AddWithValue("@Id", gvCustomers.DataKeys[row.RowIndex].Value);
                        this.ExecuteQuery(cmd, "UPDATE");
                    }
                }
            }
            btnUpdate.Visible = false;
            this.BindGrid();
        }
        public DataSet GetYesNoValue(string ColumnName)
        {
            DataTable dtVal = new DataTable();
            DataColumn column;
          
    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = ColumnName;
            dtVal.Columns.Add(column);
    
            DataSet dsVal = new DataSet();
    
            dtVal.Rows.Add("Received and Usable");
            dtVal.Rows.Add("Received but not usable");
            dtVal.Rows.Add("Not Received");
    
            dsVal.Tables.Add(dtVal);
    
            return dsVal;
        }
        protected void OnCheckedChanged(object sender, EventArgs e)
        {
            bool isUpdateVisible = false;
            CheckBox chk = (sender as CheckBox);
            if (chk.ID == "chkAll")
            {
                foreach (GridViewRow row in gvCustomers.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked = chk.Checked;
                    }
                }
            }
            CheckBox chkAll = (gvCustomers.HeaderRow.FindControl("chkAll") as CheckBox);
            chkAll.Checked = true;
            foreach (GridViewRow row in gvCustomers.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                   
    
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    for (int i = 1; i < row.Cells.Count; i++)
                    {
                       
    
                        row.Cells[i].Controls.OfType<Label>().FirstOrDefault().Visible = !isChecked;
                        if (row.Cells[i].Controls.OfType<TextBox>().ToList().Count > 0)
                        {
                            row.Cells[i].Controls.OfType<TextBox>().FirstOrDefault().Visible = isChecked;
                        }
                        if (row.Cells[i].Controls.OfType<DropDownList>().ToList().Count > 0)
                        {
                            row.Cells[i].Controls.OfType<DropDownList>().FirstOrDefault().Visible = isChecked;
                        }
                        if (isChecked && !isUpdateVisible)
                        {
                            isUpdateVisible = true;
                        }
                        if (!isChecked )
                        {
                            chkAll.Checked = false;
                        }
                        
                    }
                }
            }
            btnUpdate.Visible = isUpdateVisible;
        }
        protected void gvCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SqlCommand cmd = new SqlCommand("SELECT status,  case when status = 1 then 'Received but not usable' when status = 0 then 'Received and Usable' else 'Not Received' end as statuscurrent FROM DrugAllocate");
                DropDownList ddlstatus = (e.Row.FindControl("ddlstatus") as DropDownList);
                ddlstatus.DataSource = this.ExecuteQuery(cmd, "SELECT");
                string country = (e.Row.FindControl("lblstatus") as Label).Text;
                DataSet ds = new DataSet();
                ds = GetYesNoValue("suppStatus");
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                ddlstatus.DataSource = dt;
                ddlstatus.DataTextField = "suppStatus";
                ddlstatus.DataValueField = "suppStatus";
                ddlstatus.DataBind();
                try
                {
                    ddlstatus.Items.FindByValue(country).Selected = true;
                }
                catch { }
               
            }
        }
    }
