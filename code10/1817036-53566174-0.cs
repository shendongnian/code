    public class CurrentMDL_Singleton
    {
        public Microsoft.Office.Interop.Excel.Application CurrentMDL_Excel { get; set; }
        public Microsoft.Office.Interop.Excel.Workbook CurrentMDL_Workbook { get; set; }
        public Microsoft.Office.Interop.Excel.Worksheet CurrentMDL_Worksheet { get; set; }
        public Microsoft.Office.Interop.Excel.Range CurrentMDL_xlRange { get; set; }
        private static CurrentMDL_Singleton instance = null;
        private CurrentMDL_Singleton() {}
        
        public static CurrentMDL_Singleton Instance
        {
            get
            {
                if(instance == null)
                {
                    //Create a new instance
                    instance = new CurrentMDL_Singleton();
                }
                return instance;
            }
        }
    }
