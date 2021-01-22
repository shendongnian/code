    SolverContext context = SolverContext.GetContext();
    Model model = context.CreateModel();
    
    Decision[] slot = new Decision[10];
    
    for (int i = 0; i < slot.Length; i++)
    {
        slot[i]  = new Decision(Domain.IntegerRange(1, 5), "slot" + i.ToString());
        model.AddDecision(slot[i]);
        if (i > 0) model.AddConstraint("neighbors not equal", slot[i-1] != slot[i]);
    }
    
    model.AddConstraint("sum", Model.Sum(slot) > 20);
    
    Solution solution = context.Solve();
