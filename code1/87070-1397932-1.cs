    using (var context = new MyObjectContext(blablabla...))
    {
        var resultSet = context.MyParentEntitySet.ToList();
        return resultSet;
    }
