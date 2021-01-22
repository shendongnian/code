            string _sPathFilePDF = String.Empty;
            String v_mimetype;
            String v_encoding;
            String v_filename_extension;
            String[] v_streamids;
            Microsoft.Reporting.WinForms.Warning[] warnings;
            string _sSuggestedName = String.Empty;
  
            Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
            Microsoft.Reporting.WinForms.LocalReport objRDLC = new Microsoft.Reporting.WinForms.LocalReport();
            reportViewer1.LocalReport.ReportEmbeddedResource = "reportViewer1.rdlc";
            reportViewer1.LocalReport.DisplayName  = _sSuggestedName;
            objRDLC.DataSources.Clear();
            byte[] byteViewer = rptvFlightPlan.LocalReport.Render("PDF", null, out v_mimetype, out v_encoding, out v_filename_extension, out v_streamids, out warnings);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "*PDF files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = _sSuggestedName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream newFile = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                newFile.Write(byteViewer, 0, byteViewer.Length);
                newFile.Close();
            }
