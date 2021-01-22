    public class Test {
        // These instance variables must be nulled or Excel will not quit
        private Excel.Application xl;
        private Excel.Workbook book;
        public void DoSomething()
        {
            xl = new Excel.Application();
            xl.Visible = true;
            book = xl.Workbooks.Add(Type.Missing);
            // These variables are locally scoped, so we need not worry about them.
            // Notice I don't care about using two dots.
            Excel.Range rng = book.Worksheets[1].UsedRange;
        }
        public void CleanUp()
        {
            book = null;
            xl.Quit();
            xl = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
