    public class ProgramsData
    {
        private FieldsData fieldsData = new FieldsData();
        private PrinterData printerData = new PrinterData();
    
        public ProgramsData()
        {
    
        }
        public void SomeMethodWhichWorksWithData()
        {
            using (AutoPrintDbContext dbContext = new AutoPrintDbContext())
            {
                // work with database context here, try to make it as short as possible
            }
        }
    }
