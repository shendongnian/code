    if (a == b)
    {
        bool visibility = false;
        if (obj1.status.abc_REPORT == 'Y')
        {
            if (obj1.AnotherValue.ToBoolean() == false)
            {
                visibility = true;
            }
        }
        result.IsVisible = visibility;
    }
