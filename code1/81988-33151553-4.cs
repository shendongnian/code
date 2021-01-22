    namespace System.Data.Entity
    {
      using Linq;
      using Linq.Expressions;
      using Text;
      public static class QueryableExtensions
      {
        public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> source,
          int levelIndex, Expression<Func<TEntity, TEntity>> expression)
        {
          if (levelIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(levelIndex));
          var member = (MemberExpression)expression.Body;
          var property = member.Member.Name;
          var sb = new StringBuilder();
          for (int i = 0; i < levelIndex; i++)
          {
            if (i > 0)
              sb.Append(Type.Delimiter);
            sb.Append(property);
          }
          return source.Include(sb.ToString());
        }
      }
    }
