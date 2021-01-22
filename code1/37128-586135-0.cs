    // This could be a property
    public IList<string> GetAds()
    {
        List<string> ret = new List<string>();
        ret.Add(Ad);
        ret.Add(SoyAd);
        return ret;
    }
