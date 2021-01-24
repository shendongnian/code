    mRegxExpression = new Regex(@"^(0[1-9]|[1-2]\d|3[0-1])(0[1-9]|1[0-2])(\d{2})-(\d{5})$");
    var match = mRegxExpression.Match(per_kods.Text.Trim()));
    if(!Validate(match))
    {
        // Handle invalid.
    }
    else
    {
        // Handle valid.
    }
