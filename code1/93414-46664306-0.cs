    public ActionResult DisplayPDF()
            {
                byte[] byteArray = GetPdfFromDB(4);
                MemoryStream pdfStream = new MemoryStream();
                pdfStream.Write(byteArray, 0, byteArray.Length);
                pdfStream.Position = 0;
                return new FileStreamResult(pdfStream, "application/pdf");
            }
    
            private byte[] GetPdfFromDB(int id)
            {
                #region
                byte[] bytes = { };
                string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT Scan_Pdf_File FROM PWF_InvoiceMain WHERE InvoiceID=@Id and Enabled = 1";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows == true)
                            {
                                sdr.Read();
                                bytes = (byte[])sdr["Scan_Pdf_File"];
                            }
                        }
                        con.Close();
                    }
                }
    
                return bytes;
                #endregion
            }
