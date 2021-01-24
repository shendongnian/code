    public class ExcelHelper : IExcelHelper {
        private readonly ICustomLoadRepository customLoadRepository;
		
        public ExcelHelper(ICustomLoadRepository customLoadRepository) {
             this.customLoadRepository = customLoadRepository;
        }
		
		//...
    }
