    stepsQuery = .AsQueryable();
    
    var stepTypes = new List<string>();
    stepTypes.Add(Constants.ProcessStepTypes.Standard);
    if (includeA)
        stepTypes.Add(Constants.ProcessStepTypes.A);
    if (includeB)
        stepTypes.Add(Constants.ProcessStepTypes.B);
    
    var stepsQuery = _context.ProcessSteps.Where(u => stepTypes.Contains(u.StepType));
