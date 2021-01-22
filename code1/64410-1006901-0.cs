     {
    ReportDocument reportDocument = new ReportDocument();
   
    ParameterFields paramFields = new ParameterFields();
    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
    ParameterField paramField = new ParameterField();
    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
    paramField.Name = "@Dept";
    paramDiscreteValue.Value = TextBox1.Text.ToString();
    paramField.CurrentValues.Add(paramDiscreteValue);
    paramFields.Add(paramField);
    
    paramField = new ParameterField(); // <-- This line is added
    paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
    paramField.Name = "@Name";
    paramDiscreteValue.Value = TextBox2.Text.ToString();
    paramField.CurrentValues.Add(paramDiscreteValue);
    paramFields.Add(paramField);
    CrystalReportViewer1.ParameterFieldInfo = paramFields;
    reportDocument.Load(Server.MapPath("CrystalReport.rpt"));
    CrystalReportViewer1.ReportSource = reportDocument;
    reportDocument.SetDatabaseLogon("sa", "sa", "OPWFMS-7KYGZ7SB", "test");
}
