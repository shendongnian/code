    foreach (AnalyteDTO a in o.Analytes)
    {
        string databaseLOINC = a.loinc;
        DateTime databaseDate = o.ObservationDate.Date;
        foreach (Tuple<DateTime, String> lst in allLOINCDatesForPatient)
        {
            if (lst.Item1.Date == databaseDate && lst.Item2.Equals(databaseLOINC))
            {
                isNew = false;
                break;
            }
        }
        // no need to continue iterating if we already know the answer...
        if (!isNew)
        {
            break;
        }
    }
