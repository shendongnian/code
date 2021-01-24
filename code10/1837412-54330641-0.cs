     public class WriteExecutiveSummary : CodeActivity 
        {  
            [Category("Input")]
            [RequiredArgument]
            public InArgument<string[]> Header { get; set; }
            [Category("Input")]
            [RequiredArgument]
            public InArgument<string> PathWorkbookInput { get; set; }
            [Category("Input")]
            [RequiredArgument]
            public InArgument<string> NomeFile { get; set; }
            [Category ("Input")]
            [RequiredArgument]
            public InArgument<string> NomeSheet { get; set; }
            [Category("Output")]
            public OutArgument<string> Output { get; set; }
            protected override void Execute(CodeActivityContext context)
            {
                Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbook Nuovo = xlApp.Workbooks.Add();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(PathWorkbookInput.Get(context));
                 
                var nomeFile  = NomeFile.Get(context);
                var nomeSheet = NomeSheet.Get(context);
                Nuovo.SaveAs(System.IO.Directory.GetCurrentDirectory() + "\\" + NomeFile + NomeSheet, Excel.XlFileFormat.xlOpenXMLWorkbook);
                
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string[]> Header { get; set; }
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> PathWorkbookInput { get; set; }
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> NomeFile { get; set; }
        [Category ("Input")]
        [RequiredArgument]
        public InArgument<string> NomeSheet { get; set; }
        [Category("Output")]
        public OutArgument<string> Output { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
        Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        Excel.Workbook Nuovo = xlApp.Workbooks.Add();
        Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(PathWorkbookInput.Get(context));
             
        var nomeFile  = NomeFile.Get(context);
        var nomeSheet = NomeSheet.Get(context);
}
          
