    public void GetData(int? id)
    {
        // Check all preconditions:
        Condition.Requires(id)
            .IsNotNull()
            .IsInRange(1, 999)
            .IsNotEqualTo(128);
    }
