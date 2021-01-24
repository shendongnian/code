        //must be declared in scope
        Range myNamedRange;
        
        private void SetupEventHandlerForRange(Workbook wb, String namedRange)
        {
            //get the Range object of the namedRange
            myNamedRange = wb.Worksheets.GetRangeByName(namedRange);
            //subscribe to the SheetChange event
            this.SheetChange += new
                Excel.WorkbookEvents_SheetChangeEventHandler(
                CheckNamedRangeOnCellChange);
        }
        void CheckNamedRangeOnCellChange(object Sh, Excel.Range Target)
        {
            //get the Worksheet object
            Excel.Worksheet sheet = (Excel.Worksheet)Sh;
            //check if worksheet is the desired sheet name (optional)
            if(sheet.Name == "The Name Of The Sheet You Want To Check")
            {
                //will stay false until it finds a cell in range
                bool cellInRange = false;
                //get the range enumerator for the ALTERED range
                IEnumerator altRangeEnum = Target.GetEnumerator();
                
                while (altRangeEnum.MoveNext())
                {
                    //get the cell object and check if it is in the namedRange
                    Cell cell = (Cell)altRangeEnum.Current;
                    cellInRange = IsCellIsInRange(cell, myNamedRange);
                    //if the cell is in the namedRange break
                    //we want to continue if any of the cells altered are in
                    //the namedRange
                    if(cellInRange) break;
                }
                
                //changed cell is not in namedRange, return
                if(!cellInRange) return;
                //get the range enumerator
                IEnumerator rangeEnum = myNamedRange.GetEnumerator();
                
                while (rangeEnum.MoveNext())
                {
                    Cell cell = (Cell)rangeEnum.Current;
                    //do something with cell
                }
            }
        }
        
        public bool IsCellInRange(Cell cell, Range range)
        {
            if (cell.Row < range.Row ||
                cell.Row > range.Column ||
                cell.Column < range.Row + range.Rows.Count - 1 ||
                cell.Column > range.Column + range.Columns.Count - 1)
            {
                  //cell is outside the range we want to check
                  return false;
            }
            else
            {
                return true;
            }
        }
