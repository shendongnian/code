    public class UserInput
    {
        public decimal IncomeFromChild { get; set; }
        public decimal IncomeFromAdult { get; set; }
        public decimal IncomeFromStudent { get; set; }        
        public decimal TotalIncome => IncomeFromChild + IncomeFromAdult + IncomeFromStudent;
    }
