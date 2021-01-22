    var map = new Dictionary<CheckType, Action>
        {
            { CheckType.Form, DoSomething },
            { CheckType.QueryString, DoSomethingElse },
            { CheckType.TempData, DoWhatever }
        };
    foreach(var item in map)
    {
        if ((item.Key & theCheckType) == item.Key)
            item.Value();
    }
