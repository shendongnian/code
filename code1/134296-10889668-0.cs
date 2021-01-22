            saver.FileName = "test";
            saver.DefaultExt = "xls";
            saver.Filter = "Microsoft Office Excel Workbook |(*.xls*)";
            saver.CheckFileExists = false;
            saver.InitialDirectory = "c:\\George";
            Form dummyForm = new System.Windows.Forms.Form();
        if (saver.ShowDialog(dummyForm) == DialogResult.OK)
            //MessageBox.Show("Save Dialog launched");
            excelWorkbook.SaveAs(saver.FileName, Type.Missing, Type.Missing,Type.Missing,
            Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing);
