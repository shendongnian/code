    public IQueryable<ReinsuranceSlip> GetReinsuranceSlipsOverview(int userId, int companyId, string owner, string ownerCompany)
    {
        IQueryable<ReinsuranceSlip> model = null;
    model = _context.Request
        .Where(w => w.RequestGroup.ProgramData.MCContactId == userId)
        .Select(x => new ReinsuranceSlip()
        {
            Id = x.Id,
            RequestId = x.Id,
            LocalPolicyNumber = x.LocalPolicyNumber,
            BusinessLine = x.RequestGroup.ProgramData.BusinessLine.DisplayName,
            BusinessLineId = x.RequestGroup.ProgramData.BusinessLine.Id,
            ParentBroker = x.RequestGroup.ProgramData.Broker.Name,
            LocalBroker = x.Broker.Name,
            InceptionDate = x.InceptionDate,
            RenewDate = x.RenewDate,
            //Deductibles = GetDeductibles(x.RequestId)
        });
        CalculateDeductibles(ref model);
        return model;
    }
    
    private void CalculateDeductibles(ref IQueryable<ReinsuranceSlip> model)
    {
        foreach (var item in model)
        {
            item.Deductibles = GetDeductibles(item.RequestId);
        }
    }
