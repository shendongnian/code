    protected void Page_Load(object sender, EventArgs e)
            {
    
                if (!IsPostBack)
                {
    
                  TXTORDERID.Text = Request.QueryString["order_id"].ToString();
                    TXTDEPTID.Text = Request.QueryString["DEPT ID"].ToString();
                    TXTTESTID.Text = Request.QueryString["Test Id"].ToString();
                    ReportDocument reportDocument = new ReportDocument();
                    ParameterFields paramFields = new ParameterFields();
                    ParameterField paramField = new ParameterField();
                    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
    
    
    
                            paramField.Name = "@ORDER_ID";
                            paramDiscreteValue.Value = TXTORDERID.Text.ToString();
                            paramField.CurrentValues.Add(paramDiscreteValue);
                            paramFields.Add(paramField);
    
                            paramField = new ParameterField(); 
                            paramDiscreteValue = new ParameterDiscreteValue();  
                            paramField.Name = "@deptid";
                            paramDiscreteValue.Value = TXTDEPTID.Text.ToString();
                            paramField.CurrentValues.Add(paramDiscreteValue);
                            paramFields.Add(paramField);
    
                            CrystalReportViewer1.ParameterFieldInfo = paramFields;
                            CrystalReportViewer1.ReuseParameterValuesOnRefresh = true;
                            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                            reportDocument.Load(Server.MapPath("~/RPT/RPT_RESULT.rpt"));
                            CrystalReportViewer1.ReportSource = reportDocument;
                            reportDocument.SetDatabaseLogon("DBA", "2006");
                        }
                    }
