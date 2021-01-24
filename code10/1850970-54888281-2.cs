    var query = 
		from mv in MeasureValues
		join m in Measures on mv.MeasureID equals m.ID
		join p in Providers on mv.ProviderID equals p.ID
		where mv.ReportingDate == 
			(from mv2 in MeasureValues
			where mv2.MeasureID == mv.MeasureID
			orderby mv2.ReportingDate descending
			select mv2.ReportingDate
			).FirstOrDefault()
		select new { m.InternalID, p.Code };
    var distinct = 
		from q in query
		group q by new { q.InternalID, q.Code} into gr
		select new 
		{ 
			InternalID = gr.First().InternalID, 
			Code = gr.First().Code 
		};
    var result = distinct.ToList();
