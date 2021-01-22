    protected override List<FeatureModel> GetModels() {
        var fs = new FeatureService();
        var all = fs.FindAll();
        var wr = new WeakReference(all);
        System.Diagnostics.Debug.Assert(all != null, "FindAll must not return null");
        System.Diagnostics.Debug.WriteLine(wr.IsAlive);
        System.Diagnostics.Debug.WriteLine(all.ToString()); // throws NullReferenceException
        return all;
    }
