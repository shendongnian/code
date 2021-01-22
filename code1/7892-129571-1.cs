    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(Object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
    
            dt.Columns.Add(new DataColumn("column"));
    
            DataRow dr = null;
    
            for (Int32 i = 0; i < 10; i++)
            {
                dr = dt.NewRow();
    
                dr["column"] = "";
    
                dt.Rows.Add(dr);
            }
    
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
            
            
            foreach (RepeaterItem ri in this.Repeater1.Controls)
            {
                foreach (Control c in ri.Controls)
                {
                    Button b = new Button();
                    
                    
                    try
                    {
                        b = (Button)c;
                    }
    
                    catch (Exception exc)
                    {
                    }
    
    
                    b.Text = "I was found and changed";
                }
            }
        }
    }
