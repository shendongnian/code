    public static class EntityFrameworkExtensions
    {
        public static ObjectContext GetObjectContext(this DbContext context) 
        {
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
            return objectContext;
        }
        public static string GetTableName<T>(this ObjectSet<T> objectSet) 
            where T : class
        {
            string sql = objectSet.ToTraceString();
            Regex regex = new Regex("FROM (?<table>.*) AS");
            Match match = regex.Match(sql);
            string table = match.Groups["table"].Value;
            return table;
        }
        public static IQueryable<T> RecursiveInclude<T>(this IQueryable<T> query, Expression<Func<T, T>> navigationPropertyExpression, DbContext context)
            where T : class
        {
            var objectContext = context.GetObjectContext();
            var entityObjectSet = objectContext.CreateObjectSet<T>();
            var entityTableName = entityObjectSet.GetTableName();
            var navigationPropertyName = ((MemberExpression)navigationPropertyExpression.Body).Member.Name;
            var navigationProperty = entityObjectSet
                .EntitySet
                .ElementType
                .DeclaredNavigationProperties
                .Where(w => w.Name.Equals(navigationPropertyName))
                .FirstOrDefault();
            var association = objectContext.MetadataWorkspace
                .GetItems<AssociationType>(DataSpace.SSpace)
                .Single(a => a.Name == navigationProperty.RelationshipType.Name);
            var pkName = association.ReferentialConstraints[0].FromProperties[0].Name;
            var fkName = association.ReferentialConstraints[0].ToProperties[0].Name;
            var sqlQuery = @"
                    EXEC ('
                    	;WITH CTE AS
                    	(
                    	    SELECT 
                    			[cte1].' + @TABLE_PK + '
                    	        , Level = 1
                    	    FROM ' + @TABLE_NAME + ' [cte1]
                    	    WHERE [cte1].' + @TABLE_FK + ' IS NULL
                    	    
                    		UNION ALL
                    	    
                    		SELECT 
                    			[cte2].' + @TABLE_PK + '
                    	        , Level = CTE.Level + 1
                    	    FROM ' + @TABLE_NAME + ' [cte2]
                    	        INNER JOIN CTE ON CTE.' + @TABLE_PK + ' = [cte2].' + @TABLE_FK + '
                    	)
                    	SELECT 
                    		MAX(CTE.Level)
                    	FROM CTE 
                    ')
                ";
            var rawSqlQuery = context.Database.SqlQuery<int>(sqlQuery, new SqlParameter[]
                {
                    new SqlParameter("TABLE_NAME", entityTableName),
                    new SqlParameter("TABLE_PK", pkName),
                    new SqlParameter("TABLE_FK", fkName)
                });
            var includeCount = rawSqlQuery.FirstOrDefault();
            var include = string.Empty;
            for (var i = 0; i < (includeCount - 1); i++)
            {
                if (i > 0)
                    include += ".";
                include += navigationPropertyName;
            }
            return query.Include(include);
        }
    }
