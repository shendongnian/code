    using System.Text.RegularExpressions;
    public bool IsValidTime(string thetime)
    {
        Regex checktime =
            new Regex(@"^(20|21|22|23|[01]d|d)(([:][0-5]d){1,2})$");
        return checktime.IsMatch(thetime);
    }
