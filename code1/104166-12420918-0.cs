        /// <summary>
        /// Returns the Row or Col Count in a Worksheet
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="type"> </param>
        /// <returns></returns>
        public static int GetRowOrColCount(ExcelWorksheet worksheet, string type)
        {
            var i = 1;
            try
            {
                // Loop Infinitely
                while (true)
                {
                    var c = (type=="row")? worksheet.Cells[i, 1] : worksheet.Cells[1, i];
                    if (c.Value == null) break;
                    i++;
                }
            }
            catch (ArgumentException e){}
            return i;
        }
