    public override bool Equals(object obj)
    {
        Test test = obj as Test;
        if (obj == null)
        {
            return false;
        }
        return Value == test.Value &&
            String1 == test.String1 &&
            String2 == test.String2;
    }
