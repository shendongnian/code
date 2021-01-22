     public enum ReportType : int //Must match actual rdlc filename!!
            {
                rptBankPaymentInstructions = 0,
                rptInstructionReconciliation = 1,
                rptMarketValue = 2,
                rptPortfolioInstructionsSummary = 3
            }
    private void ShowRpt(ReportType type, string[] parametersValues, string[] parameterNames)
            {
                try
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.ReportEmbeddedResource =  "ATPresentation.Reports." + type.ToString() + ".rdlc";
                    //reportViewer1.LocalReport.ReportEmbeddedResource = "ATPresentation.Reports.rptMarketValue.rdlc";
                    ReportEngineService.ReportService rService = new ATPresentation.ReportEngineService.ReportService();
                    
    
                    ReportDataSource rds = new ReportDataSource();
                    
    
                    switch (type)
                    {
                        case ReportType.rptBankPaymentInstructions:
                            break;
                        case ReportType.rptMarketValue:
                            rds.Name = "Report_MarketValue";
    
                            ReportEngineService.Report.MarketValueDataTable dt = rService.GetMarketValueDt(Convert.ToInt32(parametersValues[0]), Convert.ToDateTime(parametersValues[1]));
                            rds.Value = dt;
                            //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Report_MarketValue",dt));
                            break;
                        default:
                            break;
                    }
    
                    List<ReportParameter> allParams = new List<ReportParameter>();
    
                    for (int i = 0; i < parametersValues.Length; i++)
                    {
                        Microsoft.Reporting.WinForms.ReportParameter rptParams = new ReportParameter( parameterNames[i], parametersValues[i]);
                        allParams.Add(rptParams);
                    }
    
                    reportViewer1.LocalReport.SetParameters(allParams);           
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.RefreshReport();
                }
                catch (Exception)
                {
                    
                    throw;
                }
    
    
            }
