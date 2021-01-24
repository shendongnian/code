    var tpCase = _DbContext.Cases
        .Where(x => x.BusinessSystemId == businessSystemId &&
                    x.CaseId == caseId)
        .Include(tpCase => tpCase.RenewalCycles.Select(renewalCycle => renewalCycle.CaseEvents.Select(caseEvent => caseEvent.TPEvent.EventClassifications)))
        .FirstOrDefault();
