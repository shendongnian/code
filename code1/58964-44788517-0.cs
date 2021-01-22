        public  string Filename;
        private  Excel.Application oexcel;
        private Excel.Workbook obook;
        private  Excel.Worksheet osheet;
        public void createPwdExcel()
        {
            try
            {
                // File name and path, here i used abc file to be 
                // stored in Bin directory in the sloution directory
                //Filename = (AppDomain.CurrentDomain.BaseDirectory + "abc.xls");
                if (File.Exists(Filename))
                {
                    File.Delete(Filename);
                }
                if (!File.Exists(Filename))
                {
                    // create new excel application
                    Excel.Application oexcel = new Excel.Application();
                    oexcel.Application.DisplayAlerts = false;
                    obook = oexcel.Application.Workbooks.Add(Type.Missing);
                    oexcel.Visible = true;
                    Console.WriteLine("Generating Auto Report");
                    osheet = (Excel.Worksheet)obook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    osheet.Name = "Test Sheet";
                    osheet.get_Range("A1:G1").Merge();
                    osheet.get_Range("A1").Value = @"Implementing Password Security on Excel Workbook Using Studio.Net";
                   
                    osheet.get_Range("A1").Interior.ColorIndex = 5;
                    osheet.get_Range("A1").Font.Bold = true;
                    string password = "abc";
                    obook.WritePassword = password;
                    obook.SaveAs("Chandra.xlsx");
                    // otherwise use the folowing one
                    // TODO: Labeled Arguments not supported. Argument: 2 := 'password'
                    // end application object and session
                    osheet = null;
                    obook.Close();
                    obook = null;
                    oexcel.Quit();
                    oexcel = null;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
