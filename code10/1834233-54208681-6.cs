        // CreateWorkBook class
        public byte[] Export_To_Excel()
        {           
            DataSet ds = getDataSetExportToExcel();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(ds);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;
                using (MemoryStream myMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(myMemoryStream);
                       
                    // return memory stream as byte array
                    return myMemoryStream.ToArray();
                }
            }
        }
        
