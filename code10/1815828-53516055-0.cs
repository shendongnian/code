    var consultants = employees
    	.SelectMany(e => e.CommissionDetailConsultants)
    	.Select(com => new ConsultantGridViewModel
    	{
    		ConsultantName = com.Consultant.Name,
    		PayRate = com.Consultant.PayRateRegular,
    		LoadedRated = com.Consultant.PayRateLoadedRegular,
    		GM = com.Consultant.GMOutput,
    		BillRate = com.Project.BillRateRegular,
    		ProjectDescription = com.Project.Description,
    		ProjectStartDate = com.Project.StartDate,
    		ProjectEndDate = com.Project.EndDate,
    		CustomerName = com.Project.Customer.Name,
    		SalesPersonName = com.SalesPerson.Name,
    		CommissionPercent = com.CommissionPercent,
    		CommissionLevel = com.Level
    	});
