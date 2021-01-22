    public void RemoveAgreement (Agreement agreement)
    {
        // Do Stuff
    }
    
    public void RemoveAgreements (IEnumerable<Agreement> agreements)
    {
        foreach (Agreement a in agreements)
        {
            RemoveAgreement(a);
        }
    }
