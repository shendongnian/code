    public static void Update(IEnumerable<Sample> samples
        , DataClassesDataContext db)
    {
        db.Samples.AttachAll(samples);
        db.Refresh(RefreshMode.KeepCurrentValues, samples)
        db.SubmitChanges();
    }
