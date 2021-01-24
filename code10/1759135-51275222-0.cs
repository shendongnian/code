    var tuples = observationsList
        .Select(o => Tuple.Create(o, !o.Analytes
            .Any(a => allLOINCDatesForPatient
                .Contains(Tuple.Create<DateTime, String>(o.ObservationDate.Date, a.loinc)))));
    foreach (var t in tuples)
    {
        var Analytes = t.Item1;
        var IsNew = t.Item2;
        Console.WriteLine("Is New?  -->> " + IsNew.ToString());
    }
