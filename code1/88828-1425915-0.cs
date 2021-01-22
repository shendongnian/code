    Policy policy = new Policy();
    
    policy.Status = Active;
    
    policyManager.InactivateAndUpdate(policy);
    
    //methods in PolicyManager
    public void Inactivate(Policy policy)
    {
        // possibly complex checks and validations might be put there in the future? ...
        policy.Status = Inactive;
    }
    
    public void InactivateAndUpdate(Policy policy)
    {
        Inactivate(policy);
        Update(policy);
    }
