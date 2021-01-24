    public virtual int Next(int maxValue) {
        if (maxValue<0) {
            throw new ArgumentOutOfRangeException("maxValue", Environment.GetResourceString("ArgumentOutOfRange_MustBePositive", "maxValue"));
        }
        Contract.EndContractBlock();
        return (int)(Sample()*maxValue);
    }
