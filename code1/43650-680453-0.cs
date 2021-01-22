    public static IQueryable<ContentSection> WithID(this IQueryable<ContentSection> qry, int ID) {
        return from c in qry select c;
    }
    //Allow you to chain repository and filter to delay SQL execution
    ICMSRepository _rep = new SqlCMSRepository();
    var sec = _rep.GetContentSections().WithID(1).SingleDefault();
