    var par = Expression.Parameter(typeof(TXLifeRequest), "txreq");
    // txreq.IsDeleted == false (simplified to !txreq.IsDeleted)
    var notIsDeleted = Expression.Not(Expression.Property(par, "IsDeleted"));
    // r => 
    var par4 = Expression.Parameter(typeof(RequirementInfo), "r");
    // OLI_LU_REQSTAT.OLI_REQSTAT_OUTSTANDING.tc
    var oli_reqstat_outstanding_tc = Expression.Constant(OLI_LU_REQSTAT.OLI_REQSTAT_OUTSTANDING.tc);
    // r.ReqStatus.tc == OLI_LU_REQSTAT.OLI_REQSTAT_OUTSTANDING.tc
    Expression<Func<RequirementInfo, bool>> any2Lambda = Expression.Lambda<Func<RequirementInfo, bool>>(Expression.Equal(Expression.Property(Expression.Property(par4, "ReqStatus"), "tc"), oli_reqstat_outstanding_tc), par4);
    // To check if it is correct
    //any2Lambda.Compile();
    // p => 
    var par3 = Expression.Parameter(typeof(Policy), "p");
    // p.RequirementInfo.Any(...)
    Expression<Func<Policy, bool>> any1Lambda = Expression.Lambda<Func<Policy, bool>>(Expression.Call(anyTSource.MakeGenericMethod(typeof(RequirementInfo)), Expression.Property(par3, "RequirementInfo"), any2Lambda), par3);
    // To check if it is correct
    //any1Lambda.Compile();
    // h => 
    var par2 = Expression.Parameter(typeof(Holding), "h");
    // h.Policy
    Expression<Func<Holding, Policy>> selectLambda = Expression.Lambda<Func<Holding, Policy>>(Expression.Property(par2, "Policy"), par2);
    // To check if it is correct
    //selectLambda.Compile();
    //txreq.OLifE.Holding
    var holding = Expression.Property(Expression.Property(par, "OLifE"), "Holding");
    // txreq.OLifE.Holding.Select(...)
    var select = Expression.Call(selectTSourceTResult.MakeGenericMethod(typeof(Holding), typeof(Policy)), holding, selectLambda);
    var any1 = Expression.Call(anyTSource.MakeGenericMethod(typeof(Policy)), select, any1Lambda);
    var and = Expression.AndAlso(notIsDeleted, any1);
    Expression<Func<TXLifeRequest, bool>> lambda = Expression.Lambda<Func<TXLifeRequest, bool>>(and, par);
    // To check if it is correct and/or use it
    //var compiled = lambda.Compile();
