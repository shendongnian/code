    protected void lnkExport_Click(object sender, EventArgs e)
            {
                var linkButton = (LinkButton)sender;
                switch (linkButton.CommandArgument)
                {
                    case "Excel":
                        rgPaymentIssues.MasterTableView.ExportToExcel();
                        break;
                    case "CSV":
                        PrepareRadGridForExport();
                        rgPaymentIssues.MasterTableView.ExportToCSV();
                        break;
                    default:
                        break;
                }
            }
