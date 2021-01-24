    PaymentHelpers.SetupPaymentMap(db);
    var parents = db.Where(p => !db.Any(p2 => p2.ParentPaymentId == p.ID));
    var parentsWithChildren = parents.Select(p => new PaymentWithChildren {
        ID = p.ID,
        Name = p.Name,
        Payment = p.Payment,
        Payments = PaymentHelpers.Parents(db, p.ID).ToArray()
    }).ToList();
