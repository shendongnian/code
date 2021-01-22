    public void GetRecord(int id)
    {
        _myentity.Schedules.Where(x => MyMethodTooLongToPutInline(x, id));
    }
    private bool MyMethodTooLongToPutInline(Models.Schedules x, int id)
    {
        //...
    }
