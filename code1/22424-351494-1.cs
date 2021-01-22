    // Child.cs
    protected override void OnCheckedChanged()
    {
        if (Check.Checked)
        {
            this.addName(this.FirstName);
        }
        base.OnCheckedChanged();  // Same outcome
    }
