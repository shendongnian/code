    var query = _context.Quetta
    	.Include(qr => qr.Category) // Not needed, will be ignored
    	.Where(qr => qr.OfferDate > DateTime.Now && qr.CatId == suplayerCat)
    	.Where(qr => !postOn.Contains(qr.Id))
    	.Select(qr => new ReqestWithQA
    	{
    		ReqText = qr.ReqText,
    		Qentity = qr.Qentity,
    		CatId = qr.CatId,
    		CatName = qr.Category.CatName,
    		District = qr.District,
    		ApplicationDate = qr.ApplicationDate,
    		DeliveryDate = qr.DeliveryDate,
    		OfferDate = qr.OfferDate,
    		TecnicalDetails = qr.TecnicalDetails,
    		Bedget = qr.Bedget,
    		Id = qr.Id,
    		QAViewModel = qr.QuoteQuestions
    			.Select(qq => new QAViewModel
    			{
    				QuoteQuestionId = qq.QuoteQuestionId,
    				QuoteId = qq.QuoteId,
    				Question = qq.Question,
    				Answers = qq.Answers,
    			})
    			.ToList()
    	});
    var result = query.ToList();
