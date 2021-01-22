    private readonly int _years;
    private readonly int _months;
    private readonly int _days;
    public int Years  { get { return _years; } }
    public int Months { get { return _months; } }
    public int Days { get { return _days; } }
    public Age( int years, int months, int days ) : this()
    {
        _years = years;
        _months = months;
        _days = days;
    }
    public static Age CalculateAge( DateTime dateOfBirth, DateTime date )
    {
        // Here is some logic that ressembles Mike's solution, although it
        // also takes into account months & days.
        // Ommitted for brevity.
        return new Age (years, months, days);
    }
    
    // Ommited Equality, Comparable, GetHashCode, functionality for brevity.
}
