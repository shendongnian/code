    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Data.SqlClient;
    
    public partial class SqlExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"MyConnectionData");
            SqlCommand command = new SqlCommand("SELECT nombre FROM Prueba WHERE Id=@zip", conn);
    
            command.Parameters.AddWithValue("@zip", this.tbZip.Text);
    
            conn.Open();
    
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    this.lblResultado.Text = reader.GetValue(0).ToString();
                }
            }
    
            conn.Close();
        }
    }
