           //create object of crystal report.
            CrystalReport1 objRpt = new CrystalReport1();
            objRpt.SetDataSource(ds);
            ParameterFields pfield = new ParameterFields();
            ParameterField ptitle = new ParameterField();
            ParameterDiscreteValue pvalue = new ParameterDiscreteValue();
            ptitle.ParameterFieldName = "date";
            pvalue.Value = txtcolor.Text;
            ptitle.CurrentValues.Add(pvalue);
            pfield.Add(ptitle);
            crystalReportViewer1.ParameterFieldInfo = pfield;
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
