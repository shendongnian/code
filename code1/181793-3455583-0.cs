    public static IEnumerable<PropertyInfo> GetNewsList<T>(int FID)
    {
        CatomWebNetDataContext pg = (CatomWebNetDataContext)db.GetDb();
        var result from nls in pg.NewsCat_ITEMs
                   join vi in pg.VIRTUAL_ITEMs on nls.NC_VI_ID equals vi.VI_ID
                   where vi.VI_VF_ID == FID
                   select new PropertyInfo { SomeMember = nls, SomeOtherMember = vi };
        return result.ToList();
    }
