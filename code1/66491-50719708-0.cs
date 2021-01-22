    public void Run(CheckType checkType)
    {
        switch (checkType)
        {
            case var type when CheckType.Form == (type & CheckType.Form):
                DoSomething(/*Some type of collection is passed */);
                break;
            case var type when CheckType.QueryString == (type & CheckType.QueryString):
                DoSomethingElse(/*Some other type of collection is passed */);
                break;
            case var type when CheckType.TempData == (type & CheckType.TempData):
                DoWhatever(/*Some different type of collection is passed */);
                break;
        }
    }
