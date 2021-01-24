    private void btnFind_Click(object sender, EventArgs e)
            {
                GetCustomer_ResultBindingSource.DataSource = db.GetCustomer(cboProduct.SelectedValue.ToString()).ToList();
    
                ReportParameter[] rParam = new ReportParameter[]
                {
                    new ReportParameter("ProductName", cboProduct.SelectedValue.ToString())
                };
    
                reportViewer1.LocalReport.SetParameters(rParam);
                reportViewer1.RefreshReport();
            }
