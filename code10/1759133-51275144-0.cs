    foreach (OneDayAnalytes o in observationsList)
    {
        bool isNew = !o.Analytes
            .Any(a => allLOINCDatesForPatient
                .Any(lst => lst.Item1.Date == o.ObservationDate.Date && lst.Item2.Equals(a.loinc)));
        Console.WriteLine("Is New?  -->> " + isNew.ToString());
    }
