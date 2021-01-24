        //Only works for single values
        private bool TryGetTimeSpan(ExcelWorksheet sheet, string address, out TimeSpan result)
        {
            var excelMinDate = DateTime.Parse("30.12.1899 00:00:00");
            try
            {
                var time = sheet.Cells[address].GetValue<DateTime>();
                result = time.Subtract(excelMinDate);
            }
            catch (FormatException)
            {
                result = TimeSpan.Zero;
                return false;
            }
            return true;
        }
