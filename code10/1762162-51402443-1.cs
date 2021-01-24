    var result = ctx.Payments.Select(payment => new
    {    // select only the properties you plan to use locally:
         Id = payment.Id,
         Date = payment.Date,
         PaymentMethod = payment.PaymentMethods?.Description,
         PaidCount = ctx.Payments
             .Where(q => q.ActivityID == p.ID && !q.Paid)
             .Count(),
    })
    .OrderBy(fetchedPaymentData => fetchedPaymentData.Id)
    // from here you need to move it to local memory
    // Use AsEnumerable instead of ToList
    .AsEnumerable()
    .Select(fetchedPaymentData => new
    {
         Id = fetchedPaymentData.Id,
         PaymentMethod = fetchedPaymentData.PaymentMethod ?? String.Empty,
         ActivityStatusId = {...}
    });
     
