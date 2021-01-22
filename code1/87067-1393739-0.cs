     public static List<MyParentEntity> GetMyParentEntity(){
    using (var context = new MyObjectContext(blablabla...))
    {
        var resultSet = from e in context.MyParentEntitySet select e;
        ((ObjectQuery)resultSet).MergeOption = MergeOption.NoTracking;
        return resultSet.ToList();
    }}
