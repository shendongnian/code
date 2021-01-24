    class LineItem
    {
        //you should probably have an id in here to differentiate objects easier
    
        public double TotalFee { get; }
        public double AmountPaid { get; }
        public double SelectedAmount { get; }
        public LineItem(double totalFee, double amountPaid, double selectedAmount)
        {
            TotalFee = totalFee;
            AmountPaid = amountPaid;
            SelectedAmount = selectedAmount;
        }
    }
