    IEnumerable<DelegateType> statementList = GetStatements();
    foreach (DelegateType statement in statementList)
    {
        statement();                   // Here is where your statement executes.
        if (!ConditionContinue())      // Check your condition here.
        {
            break;    // after this, no more statements will execute.
        }
    }
