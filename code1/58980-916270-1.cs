    public int Age
    {
        get
        {
            return _Age;
        }
        set
        {
           if (IsAgeValid(value))
               _Age = value;
           else
               throw new ArgumentOutOfRangeException("value", string.Format("value should be between {0} and {1} inclusive.", MinAge, MaxAge));
        }
    }
    private bool IsValidAge(int age)
    {
        return (age >= MinAge && age <= MaxAge);
    }
