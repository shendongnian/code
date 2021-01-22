    public int Age
    {
        get
        {
            return _Age;
        }
        set
        {
           if (IsAgeValid(value))
               throw new ArgumentOutOfRangeException("value", string.Format("value should be between {0} and {1} inclusive.", MinAge, MaxAge));
           else
               _Age = Convert.ToInt32(value);
        }
    }
    private bool IsValidAge(int age)
    {
        return (age >= MinAge && age <= MaxAge);
    }
