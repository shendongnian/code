        static string GetExcelColumnName(long columnNumber)
        {
            //max number of column per row
            const long maxColPerRow = 702;
            //find row number
            long rowNum = (columnNumber / maxColPerRow);
            //find tierable columns in the row.
            long iterable = columnNumber - (maxColPerRow * rowNum);
            //actual number of dividend for column address
            long dividend = columnNumber>maxColPerRow?iterable:columnNumber;
            string columnName = String.Empty;
            
            long modulo;
            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return rowNum+1+ columnName;
        } 
                       
