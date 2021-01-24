    var result = ctx.Activities
        .OrderBy(p => p.ID)
        .Select(p => new
        {
            Id = p.Id,
            Date = p.Date?.ToString("dd/MM/yyyy"),
            PaymentMethod = p.PaymentMethods != null ? p.PaymentMethods.Description : "",
          
            PaidCount = payments
                .Where(q => q.ActivityID == p.ID && !q.Paid)
                .Count();
        })
        .Select(p => new
        {
            Id = p.Id,
            Date = p.Date,
            ActivityStatusId = 
            {
                 // count == 0 => 1
                 // count == 1 => 8
                 // count >  1 => 10
                 // count <  0 => 87 
                 if (p.PaidCount < 0) return 87;
                 switch (p.PaidCount)
                 {
                     case 0:
                        return 0;
                     case 1:
                        return 8;
                     default:
                        return 10;
                 }
            },
        });
