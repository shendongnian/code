    List<ExShippingBillDetails> ExShippingBillDetailsList = new List<ExShippingBillDetails>();
    List<ExShippingBillDetails> ExShippingBillList = new List<ExShippingBillDetails>();
    ExShippingBillList.Add(new ExShippingBillDetails() { number = 1 });
    ExShippingBillList.Add(new ExShippingBillDetails() { number = 2 });
    ExShippingBillList.Add(new ExShippingBillDetails() { number = 3 });
    ExShippingBillDetailsList.Add(new ExShippingBillDetails(ExShippingBillList[0]));
    ExShippingBillList[0].number = 5;
    //Now changing property values doesn't affect ExShippingBillDetails list
    class ExShippingBillDetails
    {
        public int number { get; set;}
        public ExShippingBillDetails()
        {
        }
        //you need to add this constructor to copy the values
        public ExShippingBillDetails(ExShippingBillDetails n)
        {
            number = n.number;
        }
    }
