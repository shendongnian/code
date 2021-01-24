    void ApplyReward(string rewardName)
    {
        if (!rewards.ContainsKey(rewardName))
        {
            return;
        }
    
        RewardCredit credit = rewards[rewardName];
        if (!credit.Rewarded)
        {
            tokens += credit.Points;
            credit.Rewarded = true;
        }
    }
