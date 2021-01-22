    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.OleDb;
    using System.Data;
    public partial class CSVSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
            string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "E:\\FolderName\\" + ";Extended Properties='text;HDR=Yes'";
            //sample.csv is the csv which i used for my demo
            string CommandText = "select * from Sample.csv";
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            conn.Open();
            OleDbDataAdapter da=new OleDbDataAdapter(CommandText,conn);
            DataSet Sample=new DataSet();
            da.Fill(Sample);
            conn.Close();
            conn.Dispose();
            gv_csvupload.DataSource = Sample;
            gv_csvupload.DataBind();                
        }
    }
