    myObject.GetValue<int>("FieldName", value =>
    {
        if (string.IsNullOrEmpty(value))
            return 0;
        if (value == "INF")
            return int.MaxValue;
        throw new InvalidInputException();
    });
