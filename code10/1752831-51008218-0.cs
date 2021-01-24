    class CreditCard
    {
        private double credit;
        public double Credit
        {
            get { return credit; }
            set { credit = value; }
        }
    
        public CreditCard(double credit)
        {
            Credit = credit;
        }
    }
    
    static void Main()
    {
        //Outputs "10"
        Console.WriteLine(new CreditCard(10).Credit);
    }
