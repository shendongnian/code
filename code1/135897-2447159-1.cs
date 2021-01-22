    var multiCrit = nhSession.CreateMultiCriteria();
    foreach (var type in typesThatContainedSearchTypeProperty)
    {
        //maybe this class has multiple properties of the same Type
        foreach (PropertyInfo pi in type.GetProperties().Where(astp => astp.PropertyType == foo))
            multiCrit.Add(nhSession.CreateCriteria(type).Add(Restrictions.Eq(pi.Name, toSearch)));
    }
    IList results = multiCrit.List();
