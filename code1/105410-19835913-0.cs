      using System;      
       using System.Data;  
       using System.IO;  
       using System.Windows.Forms;  
        
        namespace ExportExcel  
        {      
            public partial class ExportDatatabletoExcel : Form  
            {  
                public ExportDatatabletoExcel()  
                {  
                    InitializeComponent();  
                }  
        
                private void Form1_Load(object sender, EventArgs e)
                {
                  
                    DataTable dt = new DataTable();
        
                    //Add Datacolumn
                    DataColumn workCol = dt.Columns.Add("FirstName", typeof(String));
        
                    dt.Columns.Add("LastName", typeof(String));
                    dt.Columns.Add("Blog", typeof(String));
                    dt.Columns.Add("City", typeof(String));
                    dt.Columns.Add("Country", typeof(String));
        
                    //Add in the datarow
                    DataRow newRow = dt.NewRow();
        
                    newRow["firstname"] = "Arun";
                    newRow["lastname"] = "Prakash";
                    newRow["Blog"] = "http://royalarun.blogspot.com/";
                    newRow["city"] = "Coimbatore";
                    newRow["country"] = "India";
        
                    dt.Rows.Add(newRow);
        
                    //open file
                    StreamWriter wr = new StreamWriter(@"D:\\Book1.xls");
        
                    try
                    {
        
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                        }
        
                        wr.WriteLine();
        
                        //write rows to excel file
                        for (int i = 0; i < (dt.Rows.Count); i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (dt.Rows[i][j] != null)
                                {
                                    wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                                }
                                else
                                {
                                    wr.Write("\t");
                                }
                            }
                            //go to next line
                            wr.WriteLine();
                        }
                        //close file
                        wr.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
