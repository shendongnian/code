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
                //get the range enumerator
                IEnumerator rangeEnum = myNamedRange.GetEnumerator();
                
                while (rangeEnum.MoveNext())
                {
                    Cell cell = (Cell)rangeEnum.Current;
                    //do something with cell
                }
            }
        }
