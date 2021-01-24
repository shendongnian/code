    var tuples = observationsList
        .Select(o => Tuple.Create(o, !o.Analytes
            .Any(a => allLOINCDatesForPatient.Select(t => Tuple.Create(t.Item1.Date, t.Item2))
                .Contains(Tuple.Create<DateTime, String>(o.ObservationDate.Date, a.loinc)))));
    foreach (var t in tuples)
    {
        var Analytes = t.Item1;
        var IsNew = t.Item2;
        Console.WriteLine("Is New?  -->> " + IsNew.ToString());
    }
