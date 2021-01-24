    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using System.Collections.Generic;
    
    if (download_decision == "Partial")
                {
                    //New Excel Application
                    ExcelPackage excel = new ExcelPackage();
                    var ws = excel.Workbook.Worksheets.Add(public_language);
    
                    //Name columns
                    using (ExcelRange Rng = ws.Cells[1, 1])
                    {
                        Rng.Value = public_language;
                        Rng.Style.Font.Bold = true;
                        Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }
    
                    //Name columns
                    using (ExcelRange Rng = ws.Cells[1, 2])
                    {
                        Rng.Value = "English";
                        Rng.Style.Font.Bold = true;
                        Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }
    
                    //SQL Reader
                    using (SqlConnection conn = new SqlConnection())
                    {
                        //SQL Server
                        conn.ConnectionString = sqlserver;
    
                        //Conncection establish
                        conn.Open();
    
                        //Get SQL Information
                        SqlCommand cmd = new SqlCommand("select * from" + " " + selected_table, conn);
                        SqlDataReader rdr = cmd.ExecuteReader();
    
                        int counter = 3;
    
                        while (rdr.Read())
                        {
                            string Source = (string)rdr["source"];
                            string Target = (string)rdr["target"];
    
                            //Values are written in file
                            ws.Cells[counter, 1].Value = Source;
                            ws.Cells[counter, 2].Value = Target;
    
                            counter++;
                        }
                    }
    
                    //Autofit
                    ws.Column(1).AutoFit();
                    ws.Column(2).AutoFit();
    
                    //Save and Close
                    Stream stream = File.Create(path);
                    excel.SaveAs(stream);
                    stream.Close();
                }
    
    //transfer to client
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
    
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    response.Clear();
                    response.ClearHeaders();
                    response.ClearContent();
                    response.AddHeader("content-disposition", "attachment; filename=" + filename);
                    response.AddHeader("content-type", "application/excel");
                    response.ContentType = "application/vnd.xls";
                    response.AddHeader("content-length", file.Length.ToString());
                    response.WriteFile(file.FullName);
                    response.Flush();
                    response.Close();
                }
    
                //file deleting
                File.Delete(path);
