    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections.Generic;
    
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(Object sender, EventArgs e)
        {
            #region Fill Repeater1 with some dummy data
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
            #endregion
    
            foreach (Button b in this.FindButtonsInRepeater(ref this.Repeater1))
            {
                b.Text = "I was found and changed";
            }
        }
    
    
        private List<Button> FindButtonsInRepeater(ref Repeater repeater)
        {
            List<Button> buttonsFound = new List<Button>();
            
            
            foreach (RepeaterItem ri in repeater.Controls)
            {
                foreach (Control c in ri.Controls)
                {
                    try
                    {
                        buttonsFound.Add((Button)c);
                    }
    
                    catch (Exception exc)
                    {
                    }
                }
            }
    
    
            return buttonsFound;
        }
    }
