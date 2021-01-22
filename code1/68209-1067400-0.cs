    if (a==b) {
        if (obj1.status.abc_REPORT == 'Y') {
             if (obj1.AnotherValue.ToBoolean() == false) {
                 result.IsVisible = true;
             }
             else {
                 result.IsVisible = false;
             }
        }
        else {
            result.IsVisible = false;
        }
    }
