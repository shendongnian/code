    public class Foo
    {
        public decimal Income { get; set; }
        public decimal Rate { get; set; }
        public decimal Dues
        {
            get
            {
                decimal totalDues = Math.Round((this.Income * (1 / this.Rate) * 0.01m), 2);
                return totalDues >= 5.00M ? totalDues : 5.00M;
            }
        }
    }
