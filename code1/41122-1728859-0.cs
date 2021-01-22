    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using System.IO;
    using System.Data.SqlClient;
    
    public partial class ExcuteScript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ccwebgrity;Data Source=SURAJIT\SQLEXPRESS";
    
        FileInfo file = new FileInfo(@"E:\Project Docs\MX462-PD\MX756_ModMappings1.sql");
    
        string script = file.OpenText().ReadToEnd();
    
        SqlConnection conn = new SqlConnection(sqlConnectionString);
    
        Server server = new Server(new ServerConnection(conn));
    
        server.ConnectionContext.ExecuteNonQuery(script);
        file.OpenText().Close();
    
        }
    }
