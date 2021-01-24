    public class PersonalIncome
    {
        public decimal AnualRate { get; private set; }
        public PersonalIncome(decimal paymentRate)
        {
            AnualRate = paymentRate > 300 ? paymentRate : 40_000;
        }
    }
