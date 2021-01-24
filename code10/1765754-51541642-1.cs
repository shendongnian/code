    using System;
    using System.Web;
    using System.IO;
    using System.Data;
    
    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Button1_Click(object sender, EventArgs e)
            {
                StreamWriter swExtLogFile = new StreamWriter("D:/Log/log.txt",true);
                DataTable dt = new DataTable();
               //Adding data To DataTable
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Address");
                dt.Rows.Add(1, "venki","Chennai");
                dt.Rows.Add(2, "Hanu","London");
                dt.Rows.Add(3, "john","Swiss");
               
                int i;
                swExtLogFile.Write(Environment.NewLine);
                foreach (DataRow row in dt.Rows)
                {  
                    object[] array = row.ItemArray;
                    for (i = 0; i < array.Length - 1; i++)
                    {
                       swExtLogFile.Write(array[i].ToString() + " | ");
                    }
                    swExtLogFile.WriteLine(array[i].ToString());             
                }
                swExtLogFile.Write("*****END OF DATA****"+DateTime.Now.ToString());
                swExtLogFile.Flush();
                swExtLogFile.Close();
    
            }
        }
    }
