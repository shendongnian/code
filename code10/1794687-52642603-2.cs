    void Main()
    {
    	var commissionTotal = new []
    	{
    		new BrokerMonthlyCommission_Total_AggDto { BrokerId = 1, TotalCommissionAmountBruto = 1000, TotalCommissionAmountNeto = 1000,
    			TotalDistributingFeeParticipation = 1000, BrokerName = "B1", CommissionPaymentStatusPl = 1, MinCommissionForPayment = 2 },
    		new BrokerMonthlyCommission_Total_AggDto { BrokerId = 2, TotalCommissionAmountBruto = 2000, TotalCommissionAmountNeto = 2000,
    			TotalDistributingFeeParticipation = 2000, BrokerName = "B2", CommissionPaymentStatusPl = 1, MinCommissionForPayment = 2 },
    		new BrokerMonthlyCommission_Total_AggDto { BrokerId = 3, TotalCommissionAmountBruto = 3000, TotalCommissionAmountNeto = 3000,
    			TotalDistributingFeeParticipation = 2000, BrokerName = "B3", CommissionPaymentStatusPl = 1, MinCommissionForPayment = 2 }
    	};
    	
    	var commissionSpecial = new []
    	{
    		new BrokerMonthlyCommission_SpecialPayment_AggDto { BrokerId = 1, TotalSpecialPayments = 100, PaymentStatus = 1 },
    		new BrokerMonthlyCommission_SpecialPayment_AggDto { BrokerId = 2, TotalSpecialPayments = 300, PaymentStatus = 2 },
    		new BrokerMonthlyCommission_SpecialPayment_AggDto { BrokerId = 4, TotalSpecialPayments = 900, PaymentStatus = 4 }
    	};
    	
    	var leftJoin =
    		from ct in commissionTotal
    		join cs in commissionSpecial on ct.BrokerId equals cs.BrokerId into temp
    		from cs in temp.DefaultIfEmpty(new BrokerMonthlyCommission_SpecialPayment_AggDto
    		{
    			BrokerId = ct.BrokerId,
    			TotalSpecialPayments = default(decimal),
    			PaymentStatus = default(int)
    		})
    		select new {CT = ct, CS = cs};
    	
    	var rightJoin =
    		from cs in commissionSpecial
    		join ct in commissionTotal on cs.BrokerId equals ct.BrokerId into temp
    		from ct in temp.DefaultIfEmpty(new BrokerMonthlyCommission_Total_AggDto
    		{
    			BrokerId = cs.BrokerId,
    			TotalCommissionAmountBruto = default(decimal),
    			TotalCommissionAmountNeto = default(decimal),
    			TotalDistributingFeeParticipation = default(decimal),
    			BrokerName = default(string),
    			CommissionPaymentStatusPl = default(int?),
    			MinCommissionForPayment = default(int?)
    		})
    		select new {CT = ct, CS = cs};
    	
    	var final = leftJoin.Union(rightJoin).Select(x => new FinalDto
    	{
    		BrokerId = x.CT.BrokerId,
    		TotalCommissionAmountBruto = x.CT.TotalCommissionAmountBruto,
    		TotalCommissionAmountNeto = x.CT.TotalCommissionAmountNeto,
    		TotalDistributingFeeParticipation = x.CT.TotalDistributingFeeParticipation,
    		BrokerName = x.CT.BrokerName,
    		CommissionPaymentStatusPl = x.CT.CommissionPaymentStatusPl,
    		MinCommissionForPayment = x.CT.MinCommissionForPayment,
    		TotalSpecialPayments = x.CS.TotalSpecialPayments,
    		PaymentStatus = x.CS.PaymentStatus
    	});
    	final.Dump(); // remove this line if not in LinqPad
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
