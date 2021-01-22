     if (ds.Tables[0].Rows.Count > 0)
                {
                    // Create the ZIP file that will be downloaded. Need to name the file something unique ...
                    string strNow = String.Format("{0:MMM-dd-yyyy_hh-mm-ss}", System.DateTime.Now);
                    ZipOutputStream zipOS = new ZipOutputStream(File.Create(Server.MapPath("~/TempFile/") + strNow + ".zip"));
                    zipOS.SetLevel(5); // ranges 0 to 9 ... 0 = no compression : 9 = max compression
        
                    // Loop through the dataset to fill the zip file
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        byte[] files = (byte[])(dr["Files"]);
                        //FileStream strim = new FileStream(Server.MapPath("~/TempFile/" + dr["FileName"]), FileMode.Create);
                        //strim.Write(files, 0, files.Length);
                        //strim.Close();
                        //strim.Dispose();
                        ZipEntry zipEntry = new ZipEntry(dr["FileName"].ToString());
                        zipOS.PutNextEntry(zipEntry);
                        zipOS.Write(files, 0, files.Length);
                    }
                    zipOS.Finish();
                    zipOS.Close();
        
                    FileInfo file = new FileInfo(Server.MapPath("~/TempFile/") + strNow + ".zip");
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        Response.ContentType = "application/zip";
                        Response.WriteFile(file.FullName);
                        Response.Flush();
                        file.Delete();
                        Response.End();
                    }
                }
