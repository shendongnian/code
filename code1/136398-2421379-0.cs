        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
            Excel.Name oName;
            Excel.Range oRange;
            //'using name
            oName = ExcelWorkbook1.Globals.ThisWorkbook.Names.Item("rgSignOffRecTemplate", missing, missing);
            oName.RefersToRange.Value2 = "here";
            //'using range
            oName = this.Names.Item("rgSignOffRecTemplate", missing, missing);
            oRange = oName.RefersToRange;
            oRange.Value2 = "here i am";
            //'direct access
            this.Names.Item("rgSignOffRecTemplate", missing, missing).RefersToRange.Value2 = "here i am again";
            DisplayWorkbookNames();
        }
        private void DisplayWorkbookNames() {
            for (int i = 1; i <= this.Names.Count - 1; i++) {
                Globals.Sheet1.Range["A" + i.ToString(), missing].Value2 = this.Names.Item(i, missing, missing);
            }
        }
