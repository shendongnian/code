    void Main()
    {
    	var commissionTotal = new []
    	{
    		new BrokerMonthlyCommission_Total_AggDto { BrokerId = 1, TotalCommissionAmountBruto = 1000, TotalCommissionAmountNeto = 1000,
    			TotalDistributingFeeParticipation = 1000, BrokerName = "B1", CommissionPaymentStatusPl = 1, MinCommissionForPayment = 2 },
    		new BrokerMonthlyCommission_Total_AggDto { BrokerId = 2, TotalCommissionAmountBruto = 2000, TotalCommissionAmountNeto = 2000,
    			TotalDistributingFeeParticipation = 2000, BrokerName = "B2", CommissionPaymentStatusPl = 1, MinCommissionForPayment = 2 }
    	};
    	
    	var commissionSpecial = new []
    	{
    		new BrokerMonthlyCommission_SpecialPayment_AggDto { BrokerId = 1, TotalSpecialPayments = 100, PaymentStatus = 1 },
    		new BrokerMonthlyCommission_SpecialPayment_AggDto { BrokerId = 2, TotalSpecialPayments = 300, PaymentStatus = 2 }
    	};
    	
    	var final = from ct in commissionTotal
    				join cs in commissionSpecial on ct.BrokerId equals cs.BrokerId
    				select new FinalDto
    				{
    					BrokerId = ct.BrokerId,
    					TotalCommissionAmountBruto = ct.TotalCommissionAmountBruto,
    					TotalCommissionAmountNeto = ct.TotalCommissionAmountNeto,
    					TotalDistributingFeeParticipation = ct.TotalDistributingFeeParticipation,
    					BrokerName = ct.BrokerName,
    					CommissionPaymentStatusPl  = ct.CommissionPaymentStatusPl,
    					MinCommissionForPayment = ct.MinCommissionForPayment,
    					TotalSpecialPayments = cs.TotalSpecialPayments,
    					PaymentStatus = cs.PaymentStatus
    				};
    }
    
    public class BrokerMonthlyCommission_Total_AggDto
    {
        public int BrokerId { get; set; }
        public decimal TotalCommissionAmountBruto { get; set; }
        public decimal TotalCommissionAmountNeto { get; set; }
        public decimal TotalDistributingFeeParticipation { get; set; }
        public string BrokerName { get; set; }
        public int? CommissionPaymentStatusPl { get; set; }
        public int? MinCommissionForPayment { get; set; }
    }
    
    public class BrokerMonthlyCommission_SpecialPayment_AggDto
    {
        public int BrokerId { get; set; }
        public decimal TotalSpecialPayments { get; set; }
        public int PaymentStatus { get; set; }
    }
    
    public class FinalDto
    {
        public int BrokerId { get; set; }
        public decimal TotalCommissionAmountBruto { get; set; }
        public decimal TotalCommissionAmountNeto { get; set; }
        public decimal TotalDistributingFeeParticipation { get; set; }
        public string BrokerName { get; set; }
        public int? CommissionPaymentStatusPl { get; set; }
        public int? MinCommissionForPayment { get; set; }
        public decimal TotalSpecialPayments { get; set; }
        public int PaymentStatus { get; set; }
    } 
