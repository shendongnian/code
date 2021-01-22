    [StringLengthValidator(1, 50, Ruleset = "RuleSetA", 
               MessageTemplate = "Last Name must be between 1 and 50 characters")]
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    [RelativeDateTimeValidator(-120, DateTimeUnit.Year, -18, 
                   DateTimeUnit.Year, Ruleset="RuleSetA", 
                   MessageTemplate="Must be 18 years or older.")]
    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }
    [RegexValidator(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", 
                 Ruleset = "RuleSetA")]
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
