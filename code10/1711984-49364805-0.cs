    public class SalaryManager
    {
        public SalaryManager(ISalaryCalculator salaryCalculator, ISalaryMessageFormatter _messageFormatter){
            _salaryCalculator = salaryCalculator;
            _messageFormatter = messageFormatter;
        }
        public SalaryManager() {
            this(new SalaryCalculator(), new SalaryMessageFormatter())
        }
