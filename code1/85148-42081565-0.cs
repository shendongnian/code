                    SqlDataSource sdsClogdetails = (SqlDataSource)gvRow.FindControl("sdsCLdetails");
                    if (sdsClogdetails != null)
                    {
                        DataView dv = sdsClogdetails.Select(DataSourceSelectArguments.Empty) as DataView;
                        if (dv != null)
                        {
                            DataTable dt = dv.ToTable() as DataTable;
                            if (dt != null)
                            {
                                DataRow dr = (DataRow)dt.Rows[0];
                                txtCLOG.Text = dr.ItemArray[3].ToString();
                            }
                        }
                    }
