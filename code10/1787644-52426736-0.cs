        public static void SetCellDateTimeWithMsValue(this ExcelRange cell, DateTime? value)
        {
            cell.Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss.000";
            if (!value.HasValue) return;
            cell.Value = value.Value;
        }
