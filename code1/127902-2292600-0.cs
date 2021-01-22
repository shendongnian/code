    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml.Linq;
    using System.Data;
    using System.IO;
    
    public partial class xmltest : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            XDocument xDoc = new XDocument(
                new XElement("List",
                    new XElement("Item",
                        new XAttribute("Name", "A"),
                        new XAttribute("Date", "21/01/2010 00:00:00")
                    ),
                    new XElement("Item",
                        new XAttribute("Name", "B"),
                        new XAttribute("Date", "12/01/2010 00:00:00")
                    ),
                    new XElement("Item",
                        new XAttribute("Name", "C"),
                        new XAttribute("Date", "10/01/2010 00:00:00")
                    ),
                    new XElement("Item",
                        new XAttribute("Name", "D"),
                        new XAttribute("Date", "28/01/2010 12:33:22")
                    )
                )
            );
    
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(xDoc.ToString()));
    
            DataSet dataSet2 = dataSet.Clone();
    
            dataSet2.Tables[0].Columns[1].DataType = typeof(DateTime);
    
            // painful, painful copy over code from dataset1 to dataset2 
            foreach (DataRow r in dataSet.Tables[0].Rows)
            {
    
                DataRow newRow = dataSet2.Tables[0].NewRow();
                newRow["name"] = r["name"];
                
                // maybe some regex help here 
                int d = Convert.ToInt32(r["Date"].ToString().Substring(0, 2));
                int m = Convert.ToInt32(r["Date"].ToString().Substring(3, 2));
                int y = Convert.ToInt32(r["Date"].ToString().Substring(6, 4));
                int h = Convert.ToInt32(r["Date"].ToString().Substring(11, 2));
                int mm = Convert.ToInt32(r["Date"].ToString().Substring(14, 2));
                int s = Convert.ToInt32(r["Date"].ToString().Substring(17, 2));
                newRow["Date"] = new DateTime(y, m, d, h, mm, s);
               
                dataSet2.Tables[0].Rows.Add(newRow);
    
            }
    
            GridView1.DataSource = dataSet2.Tables[0];
            GridView1.DataBind();
        }
    }
