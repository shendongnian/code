    public class FooRepo : IGenericRepo<Foo, FooQuery>
    {
        private ICollection<Foo> _allFooRecords; //Imagine this is populated
    
        public ICollection<Foo> GetWhere(Expression<Func<FooQuery, bool>> vmExpression)
        {
            var expression = Mapper.Map<Expression<Func<Foo, bool>>>(vmExpression);
            return _allFooRecords.Where(expression)
        }
    }
