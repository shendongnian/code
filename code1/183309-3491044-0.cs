    bool AMShown = false;
    bool PMShown = false;
    StringBuilder sb = new StringBuilder();
    //assuming it groups with false first:
    foreach(var timeObjGrp in collection.GroupBy(p=>p.isMatinee))
    {
        if (grpTimeObj.Key) StringBuilder.Append("(");
        foreach (var timeObjItem in timeObjGrp)
        {
            StringBuilder.Append(timeObjItem.time.ToString("h:m"));
            //IsAM should be something like Hours < 12
            if (!AMShown && timeObjItem.time.IsAM)
            {
                StringBuilder.Append("AM");
                AMShown = true;
            }
            if (!PMShown && timeObjItem.time.IsPM)
            {
                StringBuilder.Append("PM");
                PMShown = true;
            }
            StringBuilder.Append(",");
        }
        //here put something to remove last comma
        if (grpTimeObj.Key) StringBuilder.Append(")");
        StringBuilder.Append(",");
    }
    //here put something to remove last comma
