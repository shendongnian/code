    var predicate1 = PredicateBuilder.New<tb_pulizie>();
    if (selectedBus != null)
        foreach (string keyword in selectedBus)
            predicate1 = predicate1.Or(p => p.ID.Contains(keyword));
    var predicate2 = PredicateBuilder.New<tb_pulizie>();
    if (depositi != null)
        foreach (string keyword in depositi)
            predicate2 = predicate2.Or(p => p.deposito.Contains(keyword));
    var result = Context.tb_pulizie.AsExpandable().Where(predicate1.And(predicate2));
